using LPH.Core.Entities;
using System.Threading.Tasks;

namespace LPH.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Usuario> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Usuario security);
    }
}
