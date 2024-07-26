using System.Data;
using CardAccess.Application.Common.Interfaces;
using CardAccess.Domain.Entities.CaLiveConfig;
using CardAccess.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MVP.Infrastructure.Helpers;
using static CardAccess.Infrastructure.Data.Dapper.DbNames.DbNames;

namespace CardAccess.Infrastructure.Data.Dapper;

public class DapperContext<dbModelName> : IDapperDbConnection<dbModelName>
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    private readonly ICardAccessSettings _settings;
    private readonly IConnectionStringHelper _connectionStringHelper;
    public DapperContext(IConfiguration configuration, ICardAccessSettings settings, IConnectionStringHelper connectionStringHelper)
    {
        string typeName =typeof(dbModelName).Name;
        string name = nameof(dbModelName);
        if(string.IsNullOrEmpty(typeName) && string.IsNullOrEmpty(name))
        {

        }
        _settings = settings;
        _connectionStringHelper = connectionStringHelper;
        _configuration = configuration;
        _connectionString = SetConntionString();
    }
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);

    private string SetConntionString() {
        if (typeof(dbModelName) == typeof(PortalDb))
        {
            return _connectionStringHelper.GetConnectionString(
                _settings.LivePortalDatabaseServer,
                _settings.LivePortalDatabase,
                _settings.DatabaseUserName,
                _settings.DatabasePassword
            );
        }
        else if (typeof(dbModelName) == typeof(CommonMasterDb))
        {
            return _connectionStringHelper.GetConnectionString(
                _settings.LiveCommonMasterDatabaseServer,
                _settings.LiveCommonMasterDatabase,
                _settings.DatabaseUserName,
                _settings.DatabasePassword
            );
        }
        else if (typeof(dbModelName) == typeof(LoggingDb))
        {
            return _connectionStringHelper.GetConnectionString(
                _settings.LiveLoggingDatabaseServer,
                _settings.LiveLoggingDatabase,
                _settings.DatabaseUserName,
                _settings.DatabasePassword
            );
        }
        else if (typeof(dbModelName) == typeof(LiveConfigDb))
        {
            return _configuration.GetConnectionString("ContiHostingConnString") ?? "";
        }
        else if (typeof(dbModelName) == typeof(ArchiveConfigDb) || typeof(dbModelName) == typeof(ArchiveEventDb))
        {
            return _connectionStringHelper.GetConnectionString(
                _settings.LiveConfigurationServer,
                _settings.LiveConfigurationDatabase,
                _settings.DatabaseUserName,
                _settings.DatabasePassword
            );
        }
        //else if (typeof(dbModelName) == typeof(LiveEvent))
        //{
        //    return _connectionStringHelper.GetConnectionString(
        //        _settings.LiveEventsServer,
        //        _settings.LiveEventsDatabase,
        //        _settings.DatabaseUserName,
        //        _settings.EventDatabasePassword
        //    );
        //}
        else if (typeof(dbModelName) == typeof(Com))
        {
            return _connectionStringHelper.GetConnectionString(
                _settings.LiveCOMDBServer,
                _settings.LiveCOMDBDatabase,
                _settings.DatabaseUserName,
                _settings.DatabasePassword
            );
        }
        else
        {
            throw new ArgumentException($"Unknown type {typeof(dbModelName)}");
        }
    }
}
