using System.Data;
using CardAccess.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CardAccess.Infrastructure.Services;
public class DefaultDbConnectionFactory(IConfiguration configuration) : IDefaultDbConnectionFactory
{
    public IDbConnection CreateConnection() =>
        new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
}
