using AspNetCore.Identity.Dapper.Stores;
using Dapper;

namespace AspNetCore.Identity.Dapper.Providers;
internal class UserTokensProvider(IDatabaseConnectionFactory databaseConnectionFactory)
{
    public async Task<IEnumerable<UserToken>> GetTokensAsync(Guid userId) {
        var command = "SELECT * " +
                               $"FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserTokens] " +
                               "WHERE UserId = @UserId;";

        await using var sqlConnection = await databaseConnectionFactory.CreateConnectionAsync();
        return await sqlConnection.QueryAsync<UserToken>(command, new {
            UserId = userId
        });
    }
}
