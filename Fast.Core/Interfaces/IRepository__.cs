using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fast.Core.Interfaces
{
    public interface IRepository__<T> where T : class, new()
    {

        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task<bool> Post(T post);

        Task<bool> Delete(int id);

        Task<bool> Put(T post);

        Task Patch(T post);



    }
}
