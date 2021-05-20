using LPH.Core.Entities;
using System.Threading.Tasks;

namespace LPH.Core.Interfaces
{
    public interface ISecurityRepositor
    {
        Task<Usuario> GetLoginByCredentials(UserLogin login);

        Task RegisterUser(Usuario security);
    }
}
