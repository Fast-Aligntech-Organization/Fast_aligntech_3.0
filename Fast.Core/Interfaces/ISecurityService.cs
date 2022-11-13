using Fast.Core.Entities;
using System.Threading.Tasks;

namespace Fast.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Usuario> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Usuario security);
    }
}
