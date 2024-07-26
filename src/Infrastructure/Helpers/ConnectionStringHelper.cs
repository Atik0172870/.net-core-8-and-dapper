using System.Reflection;
using Microsoft.Extensions.Logging;

namespace MVP.Infrastructure.Helpers;
public class ConnectionStringHelper(ILogger<ConnectionStringHelper> logger) : IConnectionStringHelper
{
    //const string MsSqlConnStr = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Application Name={4}";
    const string MsSqlConnStr = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3};Application Name={4};TrustServerCertificate=True;";
    const string MsSqlConnStrWin = "Data Source={0};Initial Catalog={1};Persist Security Info=True;Integrated Security=True;Application Name={2};TrustServerCertificate=True;";

    public string GetConnectionString(string pServer, string pDatabase, string pUser, string pPassword)
    {
        string result = string.Empty;

        try
        {
            result = !string.IsNullOrEmpty(pUser) && (!string.IsNullOrEmpty(pPassword))
                ? string.Format(MsSqlConnStr, pServer, pDatabase, pUser, pPassword, AppName)
                : string.Format(MsSqlConnStrWin, pServer, pDatabase, AppName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "GetConnString() Error: {Message}", ex.Message);
        }

        return result;
    }

    private static string AppName => Assembly.GetExecutingAssembly().GetName().Name ?? "Unknown";
}
