using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LPH.Core.Interfaces
{
    public interface IController<TEntity> where TEntity : class, new()
    {

        Task<IActionResult> Get();

        Task<IActionResult> Get(int id);

        Task<IActionResult> Post(TEntity entity);

        Task<IActionResult> Delete(int id);

        Task<IActionResult> Put(TEntity entity);
    }
}
