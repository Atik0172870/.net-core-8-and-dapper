using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardAccess.Infrastructure.Generic;
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> Get();
    Task<T> Find(Guid uid);
    Task<T> Add(T model);
    Task<T> Update(T model);
    Task<int> Remove(T model);
}
