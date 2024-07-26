using System.Data;

namespace CardAccess.Infrastructure.Interfaces;
public interface IDefaultDbConnectionFactory
{
    IDbConnection CreateConnection();
}
