using AspNetCore.Identity.Dapper.Models;
using AspNetCore.Identity.Dapper.Stores;
using Dapper;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.Dapper.Providers;

internal class UserLoginsProvider(IDatabaseConnectionFactory databaseConnectionFactory)
{
    public async Task<IList<UserLoginInfo>> GetLoginsAsync(ApplicationUser user)
    {
        var command = "SELECT * " +
                               $"FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserLogins] " +
                               "WHERE UserId = @UserId;";

        await using var sqlConnection = await databaseConnectionFactory.CreateConnectionAsync();
        return (
                await sqlConnection.QueryAsync<UserLogin>(command, new { UserId = user.Id })
            )
            .Select(x => new UserLoginInfo(x.LoginProvider, x.ProviderKey, x.ProviderDisplayName))
            .ToList();
    }

    public async Task<ApplicationUser?> FindByLoginAsync(string loginProvider, string providerKey)
    {
        string[] command =
        [
            "SELECT UserId " +
            $"FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserLogins] " +
            "WHERE LoginProvider = @LoginProvider AND ProviderKey = @ProviderKey;"
        ];

        await using var sqlConnection = await databaseConnectionFactory.CreateConnectionAsync();
        var userId = await sqlConnection.QuerySingleOrDefaultAsync<Guid?>(command[0], new
        {
            LoginProvider = loginProvider,
            ProviderKey = providerKey
        });

        if (userId == null)
        {
            return null;
        }

        command[0] = "SELECT * " +
                     $"FROM [{databaseConnectionFactory.DbSchema}].[AspNetUsers] " +
                     "WHERE Id = @Id;";

        return await sqlConnection.QuerySingleAsync<ApplicationUser>(command[0], new { Id = userId });
    }
}
