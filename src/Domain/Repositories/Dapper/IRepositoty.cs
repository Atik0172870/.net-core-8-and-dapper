using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardAccess.Domain.Repositories.Dapper;
public interface IRepositoty<dbModelName>
{
    Task<int> AddAsync<T>(T model) where T : class;
    Task<int> UpdateAsync<T>(T model) where T : class;
    Task<int> DeleteAsync<T>(T model) where T : class;
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    Task<IEnumerable<T>> GetAllBySpAsync<T>(string spName, object spParamModel) where T : class;
    Task<T> FindAsync<T>(T model) where T : class;
}
