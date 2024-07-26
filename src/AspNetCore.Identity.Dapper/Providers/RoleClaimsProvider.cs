using System.Security.Claims;
using AspNetCore.Identity.Dapper.Stores;
using Dapper;

namespace AspNetCore.Identity.Dapper.Providers;

internal class RoleClaimsProvider(IDatabaseConnectionFactory databaseConnectionFactory)
{
    public async Task<IList<Claim>> GetClaimsAsync(Guid roleId)
    {
        var command = "SELECT * " +
                               $"FROM [{databaseConnectionFactory.DbSchema}].[AspNetRoleClaims] " +
                               "WHERE RoleId = @RoleId;";

        IEnumerable<RoleClaim> roleClaims = [];

        await using var sqlConnection = await databaseConnectionFactory.CreateConnectionAsync();
        return (
                await sqlConnection.QueryAsync<RoleClaim>(command, new { RoleId = roleId })
            )
            .Select(x => new Claim(x.ClaimType, x.ClaimValue))
            .ToList();
    }
}
