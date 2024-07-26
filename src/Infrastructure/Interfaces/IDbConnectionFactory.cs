using System.Data;

namespace CardAccess.Infrastructure.Interfaces;
public interface IPortalDbConnectionFactory
{
    IDbConnection CreateConnection();
}
public interface ICommonMasterDbConnectionFactory
{
    IDbConnection CreateConnection();
}
public interface ILoggingDbConnectionFactory
{
    IDbConnection CreateConnection();
}
public interface ICaLiveConfigDbConnectionFactory
{
    IDbConnection CreateConnection();
}
public interface ICaArchiveConfigDbConnectionFactory
{
    IDbConnection CreateConnection();
}

public interface ICaLiveEventDbConnectionFactory
{
    IDbConnection CreateConnection();
}
public interface ICaArchiveEventDbConnectionFactory
{
    IDbConnection CreateConnection();
}
public interface ICaComDbConnectionFactory
{
    IDbConnection CreateConnection();
}
