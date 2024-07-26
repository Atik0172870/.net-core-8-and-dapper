using System.Data;
using CardAccess.Infrastructure.Interfaces;
using CardAccess.Settings;
using Microsoft.Data.SqlClient;
using MVP.Infrastructure.Helpers;

namespace CardAccess.Infrastructure.Services;
public class PortalDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : IPortalDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LivePortalDatabaseServer,
            settings.LivePortalDatabase,
            settings.DatabaseUserName,
            settings.DatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
public class CommonMasterDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : ICommonMasterDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LiveCommonMasterDatabaseServer,
            settings.LiveCommonMasterDatabase,
            settings.DatabaseUserName,
            settings.DatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
public class LoggingDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : ILoggingDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LiveLoggingDatabaseServer,
            settings.LiveLoggingDatabase,
            settings.DatabaseUserName,
            settings.DatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
public class CaLiveConfigDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : ICaLiveConfigDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LiveConfigurationServer,
            settings.LiveConfigurationDatabase,
            settings.DatabaseUserName,
            settings.DatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
public class CaArchiveConfigDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : ICaArchiveConfigDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LiveConfigurationServer,
            settings.LiveConfigurationDatabase,
            settings.DatabaseUserName,
            settings.DatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
public class CaLiveEventDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : ICaLiveEventDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LiveEventsServer,
            settings.LiveEventsDatabase,
            settings.DatabaseUserName,
            settings.EventDatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
public class CaArchiveEventDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : ICaArchiveEventDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LiveEventsServer,
            settings.LiveEventsDatabase,
            settings.DatabaseUserName,
            settings.EventDatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
public class CaComDbConnectionFactory(
    ICardAccessSettings settings,
    IConnectionStringHelper connectionStringHelper) : ICaComDbConnectionFactory
{

    public IDbConnection CreateConnection()
    {
        string connectionString = connectionStringHelper.GetConnectionString(
            settings.LiveCOMDBServer,
            settings.LiveCOMDBDatabase,
            settings.DatabaseUserName,
            settings.DatabasePassword
            );

        return new SqlConnection(connectionString);
    }
}
