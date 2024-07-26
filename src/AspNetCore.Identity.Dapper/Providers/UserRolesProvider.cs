using AspNetCore.Identity.Dapper.Models;
using AspNetCore.Identity.Dapper.Stores;
using Dapper;

namespace AspNetCore.Identity.Dapper.Providers;

internal class UserRolesProvider(IDatabaseConnectionFactory databaseConnectionFactory)
{
    public async Task<IEnumerable<UserRole>> GetRolesAsync(ApplicationUser user)
    {
        var command = "SELECT r.Id AS RoleId, r.Name AS RoleName " +
                               $"FROM [{databaseConnectionFactory.DbSchema}].AspNetRoles AS r " +
                               $"INNER JOIN [{databaseConnectionFactory.DbSchema}].[AspNetUserRoles] AS ur ON ur.RoleId = r.Id " +
                               "WHERE ur.UserId = @UserId;";

        await using var sqlConnection = await databaseConnectionFactory.CreateConnectionAsync();
        return await sqlConnection.QueryAsync<UserRole>(command, new
        {
            UserId = user.Id
        });
    }
}
