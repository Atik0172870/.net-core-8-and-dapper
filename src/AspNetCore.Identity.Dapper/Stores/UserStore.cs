﻿using System.Security.Claims;
using AspNetCore.Identity.Dapper.Models;
using AspNetCore.Identity.Dapper.Providers;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.Dapper.Stores;
public class UserStore(IDatabaseConnectionFactory databaseConnectionFactory) :
    IQueryableUserStore<ApplicationUser>,
    IUserEmailStore<ApplicationUser>,
    IUserLoginStore<ApplicationUser>,
    IUserPasswordStore<ApplicationUser>,
    IUserPhoneNumberStore<ApplicationUser>,
    IUserTwoFactorStore<ApplicationUser>,
    IUserSecurityStampStore<ApplicationUser>,
    IUserClaimStore<ApplicationUser>,
    IUserLockoutStore<ApplicationUser>,
    IUserRoleStore<ApplicationUser>,
    IUserAuthenticationTokenStore<ApplicationUser>,
    IUserStore<ApplicationUser>
{
    private readonly UsersProvider _usersTable = new(databaseConnectionFactory);
    private readonly UserRolesProvider _usersRolesTable = new(databaseConnectionFactory);
    private readonly RolesProvider _rolesTable = new(databaseConnectionFactory);
    private readonly UserClaimsProvider _usersClaimsTable = new(databaseConnectionFactory);
    private readonly UserLoginsProvider _usersLoginsTable = new(databaseConnectionFactory);
    private readonly UserTokensProvider _userTokensTable = new(databaseConnectionFactory);

    #region IQueryableUserStore<ApplicationUser> Implementation
    public IQueryable<ApplicationUser> Users => Task.Run(_usersTable.GetAllUsers).Result.AsQueryable();
    #endregion

    #region IUserStore<ApplicationUser> Implementation
    public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return _usersTable.CreateAsync(user);
    }

    public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return _usersTable.DeleteAsync(user);
    }

    public Task<ApplicationUser?> FindByIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var isValidGuid = Guid.TryParse(userId, out var userGuid);

        return !isValidGuid ? Task.FromResult<ApplicationUser?>(null) : _usersTable.FindByIdAsync(userGuid);
    }

    public Task<ApplicationUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return _usersTable.FindByNameAsync(normalizedUserName);
    }

    public Task<string?> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.NormalizedUserName);
    }

    public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.Id.ToString());
    }

    public Task<string?> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.UserName);
    }

    public Task SetNormalizedUserNameAsync(ApplicationUser user, string? normalizedName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.NormalizedUserName = normalizedName;
        return Task.CompletedTask;
    }

    public Task SetUserNameAsync(ApplicationUser user, string? userName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.UserName = userName;
        return Task.CompletedTask;
    }

    public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.ConcurrencyStamp = Guid.NewGuid().ToString();
        return _usersTable.UpdateAsync(user);
    }

    #endregion IUserStore<ApplicationUser> Implementation

    #region IUserEmailStore<ApplicationUser> Implementation
    public Task SetEmailAsync(ApplicationUser user, string? email, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.Email = email;
        return Task.CompletedTask;
    }

    public Task<string?> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.Email);
    }

    public Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.EmailConfirmed);
    }

    public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.EmailConfirmed = confirmed;
        return Task.CompletedTask;
    }

    public Task<ApplicationUser?> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return _usersTable.FindByEmailAsync(normalizedEmail);
    }

    public Task<string?> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.NormalizedEmail);
    }

    public Task SetNormalizedEmailAsync(ApplicationUser user, string? normalizedEmail, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.NormalizedEmail = normalizedEmail;
        return Task.CompletedTask;
    }
    #endregion IUserEmailStore<ApplicationUser> Implementation

    #region IUserLoginStore<ApplicationUser> Implementation
    public async Task AddLoginAsync(ApplicationUser user, UserLoginInfo login, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        login.ThrowIfNull(nameof(login));
        user.Logins ??= [.. (await GetLoginsAsync(user, cancellationToken))];
        var foundLogin = user.Logins.SingleOrDefault(x => x.LoginProvider == login.LoginProvider && x.ProviderKey == login.ProviderKey);

        if (foundLogin == null)
        {
            user.Logins.Add(login);
        }
    }

    public async Task RemoveLoginAsync(ApplicationUser user, string loginProvider, string providerKey, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        loginProvider.ThrowIfNull(nameof(loginProvider));
        providerKey.ThrowIfNull(nameof(providerKey));
        user.Logins ??= [.. (await GetLoginsAsync(user, cancellationToken))];
        var login = user.Logins.SingleOrDefault(x => x.LoginProvider == loginProvider && x.ProviderKey == providerKey);

        if (login != null)
        {
            user.Logins.Remove(login);
        }
    }

    public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.Logins ??= [.. (await _usersLoginsTable.GetLoginsAsync(user))];
        return user.Logins;
    }

    public Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        loginProvider.ThrowIfNull(nameof(loginProvider));
        return _usersLoginsTable.FindByLoginAsync(loginProvider, providerKey);
    }
    #endregion IUserLoginStore<ApplicationUser> Implementation

    #region IUserPasswordStore<ApplicationUser> Implementation
    public Task SetPasswordHashAsync(ApplicationUser user, string? passwordHash, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        passwordHash.ThrowIfNull(nameof(passwordHash));
        user.PasswordHash = passwordHash;
        return Task.CompletedTask;
    }

    public Task<string?> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.PasswordHash);
    }

    public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
    }
    #endregion IUserPasswordStore<ApplicationUser> Implementation

    #region IUserPhoneNumberStore<ApplicationUser> Implementation
    public Task SetPhoneNumberAsync(ApplicationUser user, string? phoneNumber, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.PhoneNumber = phoneNumber;
        return Task.CompletedTask;
    }

    public Task<string?> GetPhoneNumberAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.PhoneNumber);
    }

    public Task<bool> GetPhoneNumberConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.PhoneNumberConfirmed);
    }

    public Task SetPhoneNumberConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.PhoneNumberConfirmed = confirmed;
        return Task.CompletedTask;
    }
    #endregion IUserPhoneNumberStore<ApplicationUser> Implementation

    #region IUserTwoFactorStore<ApplicationUser> Implementation
    public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.TwoFactorEnabled = enabled;
        return Task.CompletedTask;
    }

    public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.TwoFactorEnabled);
    }
    #endregion IUserTwoFactorStore<ApplicationUser> Implementation

    #region IUserSecurityStampStore<ApplicationUser> Implementation
    public Task SetSecurityStampAsync(ApplicationUser user, string stamp, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        stamp.ThrowIfNull(nameof(stamp));
        user.SecurityStamp = stamp;
        return Task.FromResult<object?>(null);
    }

    public Task<string?> GetSecurityStampAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.SecurityStamp);
    }
    #endregion IUserSecurityStampStore<ApplicationUser> Implementation

    #region IUserClaimStore<ApplicationUser> Implementation
    public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.Claims ??= [.. (await _usersClaimsTable.GetClaimsAsync(user))];
        return user.Claims;
    }

    public async Task AddClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        claims.ThrowIfNull(nameof(claims));
        user.Claims ??= [.. (await GetClaimsAsync(user, cancellationToken))];

        foreach (var claim in claims)
        {
            var foundClaim = user.Claims.FirstOrDefault(x => x.Type == claim.Type);

            if (foundClaim != null)
            {
                user.Claims.Remove(foundClaim);
                user.Claims.Add(claim);
            }
            else
            {
                user.Claims.Add(claim);
            }
        }
    }

    public async Task ReplaceClaimAsync(ApplicationUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        claim.ThrowIfNull(nameof(claim));
        newClaim.ThrowIfNull(nameof(newClaim));
        user.Claims ??= [.. (await GetClaimsAsync(user, cancellationToken))];
        var foundClaim = user.Claims.FirstOrDefault(x => x.Type == claim.Type && x.Value == claim.Value);

        if (foundClaim != null)
        {
            foundClaim = newClaim;
        }
        else
        {
            user.Claims.Add(newClaim);
        }
    }

    public async Task RemoveClaimsAsync(ApplicationUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        claims.ThrowIfNull(nameof(claims));
        user.Claims ??= [.. (await GetClaimsAsync(user, cancellationToken))];

        foreach (var claim in claims)
        {
            user.Claims.Remove(claim);
        }
    }

    public Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        claim.ThrowIfNull(nameof(claim));
        return _usersTable.GetUsersForClaimAsync(claim);
    }
    #endregion IUserClaimStore<ApplicationUser> 

    #region IUserLockoutStore<ApplicationUser> Implementation
    public Task<DateTimeOffset?> GetLockoutEndDateAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.LockoutEnd);
    }

    public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.LockoutEnd = lockoutEnd?.UtcDateTime;
        return Task.CompletedTask;
    }

    public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.AccessFailedCount++;
        return Task.FromResult(user.AccessFailedCount);
    }

    public Task ResetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.AccessFailedCount = 0;
        return Task.CompletedTask;
    }

    public Task<int> GetAccessFailedCountAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.AccessFailedCount);
    }

    public Task<bool> GetLockoutEnabledAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        return Task.FromResult(user.LockoutEnabled);
    }

    public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.LockoutEnabled = enabled;
        return Task.CompletedTask;
    }
    #endregion IUserLockoutStore<ApplicationUser> Implementation

    #region IUserRoleStore<ApplicationUser> Implementation
    public async Task AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        roleName.ThrowIfNull(nameof(roleName));
        var role = await _rolesTable.FindByNameAsync(roleName);

        if (role == null)
        {
            return;
        }

        user.Roles ??= (await _usersRolesTable.GetRolesAsync(user)).ToList();

        if (await IsInRoleAsync(user, roleName, cancellationToken))
        {
            return;
        }

        user.Roles.Add(new UserRole
        {
            RoleName = roleName,
            RoleId = role.Id
        });
    }

    public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        roleName.ThrowIfNull(nameof(roleName));
        user.Roles ??= (await _usersRolesTable.GetRolesAsync(user)).ToList();
        var role = user.Roles.SingleOrDefault(x => string.Equals(x.RoleName, roleName, StringComparison.InvariantCultureIgnoreCase));

        if (role != null)
        {
            user.Roles.Remove(role);
        }
    }

    public async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        user.Roles ??= (await _usersRolesTable.GetRolesAsync(user)).ToList();
        return user.Roles.Select(x => x.RoleName).ToList();
    }

    public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        roleName.ThrowIfNull(nameof(roleName));
        user.Roles ??= (await _usersRolesTable.GetRolesAsync(user)).ToList();
        return user.Roles.Any(x => string.Equals(x.RoleName, roleName, StringComparison.InvariantCultureIgnoreCase));
    }

    public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        return _usersTable.GetUsersInRoleAsync(roleName);
    }
    #endregion IUserRoleStore<ApplicationUser> Implementation

    #region IUserAuthenticationTokenStore<ApplicationUser> Implementation
    public async Task SetTokenAsync(ApplicationUser user, string loginProvider, string name, string? value, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        loginProvider.ThrowIfNull(nameof(loginProvider));
        user.Tokens ??= (await _userTokensTable.GetTokensAsync(user.Id)).ToList();

        user.Tokens.Add(new UserToken
        {
            UserId = user.Id,
            LoginProvider = loginProvider,
            Name = name,
            Value = value!
        });
    }

    public async Task RemoveTokenAsync(ApplicationUser user, string loginProvider, string name, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        loginProvider.ThrowIfNull(nameof(loginProvider));
        user.Tokens ??= (await _userTokensTable.GetTokensAsync(user.Id)).ToList();
        var token = user.Tokens.SingleOrDefault(x => x.LoginProvider == loginProvider && x.Name == name);
        if (token != null)
        {
            user.Tokens.Remove(token);
        }
    }

    public async Task<string?> GetTokenAsync(ApplicationUser user, string loginProvider, string name, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        user.ThrowIfNull(nameof(user));
        loginProvider.ThrowIfNull(nameof(loginProvider));
        name.ThrowIfNull(nameof(name));
        user.Tokens ??= (await _userTokensTable.GetTokensAsync(user.Id)).ToList();
        return user.Tokens.SingleOrDefault(x => x.LoginProvider == loginProvider && x.Name == name)?.Value;
    }
    #endregion

    private static void ReleaseUnmanagedResources()
    {
        // release unmanaged resources here
    }

    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~UserStore()
    {
        Dispose(false);
    }
}
