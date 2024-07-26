namespace MVP.Infrastructure.Helpers;

public interface IConnectionStringHelper
{
    string GetConnectionString(string pServer, string pDatabase, string pUser, string pPassword);
}
