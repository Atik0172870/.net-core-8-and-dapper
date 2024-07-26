using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using AspNetCore.Identity.Dapper.Models;
using Dapper;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.Dapper.Providers;
internal class UsersProvider(IDatabaseConnectionFactory databaseConnectionFactory)
{
    public async Task<IdentityResult> CreateAsync(ApplicationUser user)
    {
       const string command = @"
                INSERT INTO [dbo].[AspNetUsers] (
                    [Id],
                    [OperatorID],
                    [RoleID],
                    [OperFName],
                    [OperLName],
                    [OperLoginName],
                    [Enabled],
                    [OperPassword],
                    [PhoneNo],
                    [EmailID],
                    [PagerID],
                    [LastLoggedIn],
                    [LastLoggedInUncName],
                    [LogoffTime],
                    [AutoAckTime],
                    [LastUpdated],
                    [PasswordRequiresUpdate],
                    [IsGlobalAdministrator],
                    [MaxThreatLevelAllowed],
                    [CanChangeThreatLevel],
                    [UseLegacyDisplay],
                    [ManualPrivileges],
                    [OperSNPPHostID],
                    [OperUseSNPP],
                    [OperUseEmail],
                    [ColorScheme],
                    [PasswordExpiresIn],
                    [LoginAttempts],
                    [DisableLogoff],
                    [LanguageId],
                    [EventCount],
                    [LastOperator],
                    [LastWorkStation],
                    [UTCOffset],
                    [OperUseSMS],
                    [OperSMSHostID],
                    [LastPosPhoto],
                    [LastPosVideo],
                    [LastPosResp],
                    [LastPosMap],
                    [CompanyId],
                    [ParentCompanyId],
                    [OperType],
                    [IsportalUser],
                    [ShowGuide],
                    [HideBusyDlg],
                    [MobileAppConfig],
                    [PasswordChangedOn],
                    [DefaultPage],
                    [IsComnetManagedUser],
                    [AuthenticatorKey],
                    [UserName],
                    [NormalizedUserName],
                    [Email],
                    [NormalizedEmail],
                    [EmailConfirmed],
                    [PasswordHash],
                    [SecurityStamp],
                    [ConcurrencyStamp],
                    [PhoneNumber],
                    [PhoneNumberConfirmed],
                    [TwoFactorEnabled],
                    [LockoutEnd],
                    [LockoutEnabled],
                    [AccessFailedCount]
                ) VALUES (
                    @Id,
                    @OperatorID,
                    @RoleID,
                    @OperFName,
                    @OperLName,
                    @OperLoginName,
                    @Enabled,
                    @OperPassword,
                    @PhoneNo,
                    @EmailID,
                    @PagerID,
                    @LastLoggedIn,
                    @LastLoggedInUncName,
                    @LogoffTime,
                    @AutoAckTime,
                    @LastUpdated,
                    @PasswordRequiresUpdate,
                    @IsGlobalAdministrator,
                    @MaxThreatLevelAllowed,
                    @CanChangeThreatLevel,
                    @UseLegacyDisplay,
                    @ManualPrivileges,
                    @OperSNPPHostID,
                    @OperUseSNPP,
                    @OperUseEmail,
                    @ColorScheme,
                    @PasswordExpiresIn,
                    @LoginAttempts,
                    @DisableLogoff,
                    @LanguageId,
                    @EventCount,
                    @LastOperator,
                    @LastWorkStation,
                    @UTCOffset,
                    @OperUseSMS,
                    @OperSMSHostID,
                    @LastPosPhoto,
                    @LastPosVideo,
                    @LastPosResp,
                    @LastPosMap,
                    @CompanyId,
                    @ParentCompanyId,
                    @OperType,
                    @IsportalUser,
                    @ShowGuide,
                    @HideBusyDlg,
                    @MobileAppConfig,
                    @PasswordChangedOn,
                    @DefaultPage,
                    @IsComnetManagedUser,
                    @AuthenticatorKey,
                    @UserName,
                    @NormalizedUserName,
                    @Email,
                    @NormalizedEmail,
                    @EmailConfirmed,
                    @PasswordHash,
                    @SecurityStamp,
                    @ConcurrencyStamp,
                    @PhoneNumber,
                    @PhoneNumberConfirmed,
                    @TwoFactorEnabled,
                    @LockoutEnd,
                    @LockoutEnabled,
                    @AccessFailedCount
                );
            ";


        return await ExecuteCommandAsync(command, user, nameof(CreateAsync));
    }

    public async Task<IdentityResult> DeleteAsync(ApplicationUser user)
    {
        string command = $@"
                DELETE FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers] 
                WHERE Id = @Id;";

        return await ExecuteCommandAsync(command, new { user.Id }, nameof(DeleteAsync), user.Email);
    }

    public async Task<ApplicationUser?> FindByIdAsync(Guid userId)
    {
        string command = $@"
                SELECT * FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers] 
                WHERE Id = @Id;";

        return await QuerySingleOrDefaultAsync<ApplicationUser>(command, new { Id = userId });
    }

    public async Task<ApplicationUser?> FindByNameAsync(string normalizedUserName)
    {
        string command = $@"
                SELECT * FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers] 
                WHERE NormalizedUserName = @NormalizedUserName;";

        return await QuerySingleOrDefaultAsync<ApplicationUser>(command, new { NormalizedUserName = normalizedUserName });
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string normalizedEmail)
    {
        string command = $@"
                SELECT * FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers] 
                WHERE NormalizedEmail = @NormalizedEmail;";

        return await QuerySingleOrDefaultAsync<ApplicationUser>(command, new { NormalizedEmail = normalizedEmail });
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser user)
    {
        string command = $@"
         UPDATE [{databaseConnectionFactory.DbSchema}].[AspNetUsers] 
         SET UserName = @UserName, NormalizedUserName = @NormalizedUserName, Email = @Email, 
             NormalizedEmail = @NormalizedEmail, EmailConfirmed = @EmailConfirmed, 
             PasswordHash = @PasswordHash, SecurityStamp = @SecurityStamp, 
             ConcurrencyStamp = @ConcurrencyStamp, PhoneNumber = @PhoneNumber, 
             PhoneNumberConfirmed = @PhoneNumberConfirmed, TwoFactorEnabled = @TwoFactorEnabled, 
             LockoutEnd = @LockoutEnd, LockoutEnabled = @LockoutEnabled, 
             AccessFailedCount = @AccessFailedCount
         WHERE Id = @Id;";


        return await ExecuteTransactionAsync(user, command);
    }

    public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName)
    {
        string command = $@"
                SELECT u.* FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers] u 
                INNER JOIN [{databaseConnectionFactory.DbSchema}].[AspNetUserRoles] ur ON u.Id = ur.UserId 
                INNER JOIN [{databaseConnectionFactory.DbSchema}].AspNetRoles r ON ur.RoleId = r.Id 
                WHERE r.Name = @RoleName;";

        return await QueryAsync<ApplicationUser>(command, new { RoleName = roleName });
    }

    public async Task<IList<ApplicationUser>> GetUsersForClaimAsync(Claim claim)
    {
        string command = $@"
                SELECT u.* FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers] u 
                INNER JOIN [{databaseConnectionFactory.DbSchema}].[AspNetUserClaims] uc ON u.Id = uc.UserId 
                WHERE uc.ClaimType = @ClaimType AND uc.ClaimValue = @ClaimValue;";

        return await QueryAsync<ApplicationUser>(command, new { ClaimType = claim.Type, ClaimValue = claim.Value });
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
    {
        string command = $@"
                SELECT * FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers];";

        return await QueryAsync<ApplicationUser>(command);
    }

    private async Task<IdentityResult> ExecuteCommandAsync(string command, object parameters, string methodName, string? email = null)
    {
        try
        {
            await using var connection = await databaseConnectionFactory.CreateConnectionAsync();
            int rowsAffected = await connection.ExecuteAsync(command, parameters);

            return rowsAffected == 1
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError { Code = methodName, Description = $"User with email {email} could not be processed." });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return IdentityResult.Failed(new IdentityError { Code = methodName, Description = $"User with email {email} could not be processed." });
        }
    }

    private async Task<T?> QuerySingleOrDefaultAsync<T>(string command, object parameters)
    {
        await using var connection = await databaseConnectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<T>(command, parameters);
    }

    private async Task<IList<T>> QueryAsync<T>(string command, object? parameters = null)
    {
        await using var connection = await databaseConnectionFactory.CreateConnectionAsync();
        return (await connection.QueryAsync<T>(command, parameters)).ToList();
    }

    private async Task<IdentityResult> ExecuteTransactionAsync(ApplicationUser user, string updateUserCommand)
    {
        await using var connection = await databaseConnectionFactory.CreateConnectionAsync();
        await using var transaction = await connection.BeginTransactionAsync();

        try
        {
            await connection.ExecuteAsync(updateUserCommand, user, transaction);

            await UpdateUserClaimsAsync(user, connection, transaction);
            await UpdateUserLoginsAsync(user, connection, transaction);
            await UpdateUserRolesAsync(user, connection, transaction);
            await UpdateUserTokensAsync(user, connection, transaction);

            await transaction.CommitAsync();
            return IdentityResult.Success;
        }
        catch
        {
            await transaction.RollbackAsync();
            return IdentityResult.Failed(new IdentityError
            {
                Code = nameof(UpdateAsync),
                Description = $"User with email {user.Email} could not be updated."
            });
        }
    }

    private async Task UpdateUserClaimsAsync(ApplicationUser user, IDbConnection connection, IDbTransaction transaction)
    {
        if (user.Claims == null || user.Claims.Count == 0) return;

        string deleteCommand = $@"
                DELETE FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserClaims] 
                WHERE UserId = @UserId;";
        string insertCommand = $@"
                INSERT INTO [{databaseConnectionFactory.DbSchema}].[AspNetUserClaims] 
                (UserId, ClaimType, ClaimValue) VALUES (@UserId, @ClaimType, @ClaimValue);";

        if (connection != null)
        {
            await connection.ExecuteAsync(deleteCommand, new { UserId = user.Id }, transaction);
            await connection.ExecuteAsync(insertCommand, user.Claims.Select(c => new { UserId = user.Id, c.Type, c.Value }), transaction);
        }
    }

    private async Task UpdateUserLoginsAsync(ApplicationUser user, IDbConnection connection, IDbTransaction transaction)
    {
        if (user.Logins == null || user.Logins.Count == 0) return;

        string deleteCommand = $@"
                DELETE FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserLogins] 
                WHERE UserId = @UserId;";
        string insertCommand = $@"
                INSERT INTO [{databaseConnectionFactory.DbSchema}].[AspNetUserLogins] 
                (LoginProvider, ProviderKey, ProviderDisplayName, UserId) 
                VALUES (@LoginProvider, @ProviderKey, @ProviderDisplayName, @UserId);";

        if (connection != null)
        {
            await connection.ExecuteAsync(deleteCommand, new { UserId = user.Id }, transaction);
            await connection.ExecuteAsync(insertCommand, user.Logins.Select(l => new { l.LoginProvider, l.ProviderKey, l.ProviderDisplayName, UserId = user.Id }), transaction);
        }
    }

    private async Task UpdateUserRolesAsync(ApplicationUser user, IDbConnection connection, IDbTransaction transaction)
    {
        if (user.Roles == null || user.Roles.Count == 0) return;

        string deleteCommand = $@"
                DELETE FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserRoles] 
                WHERE UserId = @UserId;";
        string insertCommand = $@"
                INSERT INTO [{databaseConnectionFactory.DbSchema}].[AspNetUserRoles] 
                (UserId, RoleId) VALUES (@UserId, @RoleId);";

        if (connection != null)
        {
            await connection.ExecuteAsync(deleteCommand, new { UserId = user.Id }, transaction);
            await connection.ExecuteAsync(insertCommand, user.Roles.Select(r => new { UserId = user.Id, r.RoleId }), transaction);
        }
    }

    private async Task UpdateUserTokensAsync(ApplicationUser user, IDbConnection connection, IDbTransaction transaction)
    {
        if (user.Tokens == null || user.Tokens.Count == 0) return;

        string deleteCommand = $@"
                DELETE FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserTokens] 
                WHERE UserId = @UserId;";
        string insertCommand = $@"
                INSERT INTO [{databaseConnectionFactory.DbSchema}].[AspNetUserTokens] 
                (UserId, LoginProvider, Name, Value) VALUES (@UserId, @LoginProvider, @Name, @Value);";

        if (connection != null)
        {
            await connection.ExecuteAsync(deleteCommand, new { UserId = user.Id }, transaction);
            await connection.ExecuteAsync(insertCommand, user.Tokens.Select(t => new { UserId = user.Id, t.LoginProvider, t.Name, t.Value }), transaction);
        }
    }
}
