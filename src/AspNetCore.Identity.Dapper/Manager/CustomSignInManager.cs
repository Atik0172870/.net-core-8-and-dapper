using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCore.Identity.Dapper.Manager;

public class CustomSignInManager<TUser>(
    UserManager<TUser> userManager,
    IHttpContextAccessor contextAccessor,
    IUserClaimsPrincipalFactory<TUser> claimsFactory,
    IOptions<IdentityOptions> optionsAccessor,
    ILogger<SignInManager<TUser>> logger,
    IAuthenticationSchemeProvider schemes) : SignInManager<TUser>(
        userManager,
        contextAccessor,
        claimsFactory, 
        optionsAccessor, 
        logger,
        schemes) where TUser : class
{
    public override async Task<SignInResult> CheckPasswordSignInAsync(TUser user, string password, bool lockoutOnFailure)
    {
        ArgumentNullException.ThrowIfNull(user);

        var error = await PreSignInCheck(user);
        if (error != null)
        {
            return error;
        }

        if (await UserManager.CheckPasswordAsync(user, password))
        {
            var alwaysLockout = AppContext.TryGetSwitch("Microsoft.AspNetCore.Identity.CheckPasswordSignInAlwaysResetLockoutOnSuccess", out var enabled) && enabled;
            // Only reset the lockout when not in quirks mode if either TFA is not enabled or the client is remembered for TFA.
            if (alwaysLockout || !await IsTwoFactorEnabledAsync(user) || await IsTwoFactorClientRememberedAsync(user))
            {
                var resetLockoutResult = await ResetLockoutWithResult(user);
                if (!resetLockoutResult.Succeeded)
                {
                    // ResetLockout got an unsuccessful result that could be caused by concurrency failures indicating an
                    // attacker could be trying to bypass the MaxFailedAccessAttempts limit. Return the same failure we do
                    // when failing to increment the lockout to avoid giving an attacker extra guesses at the password.
                    return SignInResult.Failed;
                }
            }

            return SignInResult.Success;
        }
     

        if (UserManager.SupportsUserLockout && lockoutOnFailure)
        {
            // If lockout is requested, increment access failed count which might lock out the user
            var incrementLockoutResult = await UserManager.AccessFailedAsync(user) ?? IdentityResult.Success;
            if (!incrementLockoutResult.Succeeded)
            {
                // Return the same failure we do when resetting the lockout fails after a correct password.
                return SignInResult.Failed;
            }

            if (await UserManager.IsLockedOutAsync(user))
            {
                return await LockedOut(user);
            }
        }
        return SignInResult.Failed;
    }
    public virtual async Task<bool> IsTwoFactorEnabledAsync(TUser user)
      => UserManager.SupportsUserTwoFactor &&
      await UserManager.GetTwoFactorEnabledAsync(user) &&
      (await UserManager.GetValidTwoFactorProvidersAsync(user)).Count > 0;
    private async Task<IdentityResult> ResetLockoutWithResult(TUser user)
    {
        // Avoid relying on throwing an exception if we're not in a derived class.
        if (GetType() == typeof(SignInManager<TUser>))
        {
            if (!UserManager.SupportsUserLockout)
            {
                return IdentityResult.Success;
            }

            return await UserManager.ResetAccessFailedCountAsync(user) ?? IdentityResult.Success;
        }

        try
        {
            var resetLockoutTask = ResetLockout(user);

            if (resetLockoutTask is Task<IdentityResult> resultTask)
            {
                return await resultTask ?? IdentityResult.Success;
            }

            await resetLockoutTask;
            return IdentityResult.Success;
        }
        catch (Exception)
        {
            return IdentityResult.Failed();
        }
    }
}
