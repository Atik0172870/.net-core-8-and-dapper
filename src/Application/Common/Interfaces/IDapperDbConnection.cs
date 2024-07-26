using System.Data;

namespace CardAccess.Application.Common.Interfaces;

public interface IDapperDbConnection<dbModelName>
{
    public IDbConnection CreateConnection();
}
