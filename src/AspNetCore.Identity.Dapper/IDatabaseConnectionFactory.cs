using Microsoft.Data.SqlClient;

namespace AspNetCore.Identity.Dapper;

public interface IDatabaseConnectionFactory
{
    Task<SqlConnection> CreateConnectionAsync();
    string DbSchema { get; set; }
}
