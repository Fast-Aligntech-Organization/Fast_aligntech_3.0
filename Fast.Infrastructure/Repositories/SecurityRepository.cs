using Fast.Core.Entities;
using Fast.Core.Interfaces;
using Fast.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Fast.Infrastructure.Repositories
{
    public class SecurityRepository : RepositoryBase<Usuario>, ISecurityRepositor
    {



        public SecurityRepository(LPHDBContext context) : base(context)
        {

        }


        public async Task<Usuario> GetLoginByCredentials(UserLogin login)
        {
            var list = await base.GetAllAsync();
            var result = list.FirstOrDefault(x => x.Email == login.Email || login.Email == x.Telefono);

            return result;
        }

        public async Task RegisterUser(Usuario security)
        {
            await base.CreateAsync(security);

        }
    }
}
