using System.Resources;
using System.Security.Claims;
using AspNetCore.Identity.Dapper.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AspNetCore.Identity.Dapper.Manager;
public class CustomUserManager(
    IUserStore<ApplicationUser> store, 
    IOptions<IdentityOptions> optionsAccessor, 
    IPasswordHasher<ApplicationUser> passwordHasher, 
    IEnumerable<IUserValidator<ApplicationUser>> userValidators, 
    IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, 
    ILookupNormalizer keyNormalizer, 
    IdentityErrorDescriber errors, 
    IServiceProvider services, 
    ILogger<UserManager<ApplicationUser>> logger) : UserManager<ApplicationUser>(
        store, 
        optionsAccessor,
        passwordHasher, 
        userValidators,
        passwordValidators,
        keyNormalizer,
        errors, 
        services, 
        logger)
{
    public override async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role)
    {
        ThrowIfDisposed();
        var userRoleStore = GetUserRoleStore();
      

        var normalizedRole = NormalizeName(role);
        if (await userRoleStore.IsInRoleAsync(user, normalizedRole, CancellationToken).ConfigureAwait(false))
        {
            return UserAlreadyInRoleError(role);
        }
        await userRoleStore.AddToRoleAsync(user, normalizedRole, CancellationToken).ConfigureAwait(false);
        return await UpdateUserAsync(user).ConfigureAwait(false);
    }

    private IUserRoleStore<ApplicationUser> GetUserRoleStore()
    {
        var cast = Store as IUserRoleStore<ApplicationUser>;
        if (cast == null)
        {
            throw new NotSupportedException();
        }
        return cast;
    }

    private IdentityResult UserAlreadyInRoleError(string role)
    {
        if (Logger.IsEnabled(LogLevel.Debug))
        {
            
        }
        return IdentityResult.Failed(ErrorDescriber.UserAlreadyInRole(role));
    }


}
