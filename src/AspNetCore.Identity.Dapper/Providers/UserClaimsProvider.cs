using System.Security.Claims;
using AspNetCore.Identity.Dapper.Models;
using AspNetCore.Identity.Dapper.Stores;
using Dapper;

namespace AspNetCore.Identity.Dapper.Providers;

internal class UserClaimsProvider(IDatabaseConnectionFactory databaseConnectionFactory)
{
    public async Task<IList<Claim>> GetClaimsAsync(ApplicationUser user) {
         var command = "SELECT * " +
                               $"FROM [{databaseConnectionFactory.DbSchema}].[AspNetUserClaims] " +
                               "WHERE UserId = @UserId;";

         await using var sqlConnection = await databaseConnectionFactory.CreateConnectionAsync();
         return (
                 await sqlConnection.QueryAsync<UserClaim>(command, new { UserId = user.Id })
             )
             .Select(e => new Claim(e.ClaimType, e.ClaimValue))
             .ToList();
    }
}
