using Fast.Core.Entities;
using System.Threading.Tasks;

namespace Fast.Core.Interfaces
{
    public interface ISecurityRepositor
    {
        Task<Usuario> GetLoginByCredentials(UserLogin login);

        Task RegisterUser(Usuario security);
    }
}
