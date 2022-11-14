
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fast.Core;
using Fast.Data;

namespace Fast.Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase<PrivateUser,string>, IAccountRepository
    {


         readonly IMapper _mapper;
       
        public AccountRepository(ApplicationDbContext context,IMapper mapper ) : base(context)
        {
            _mapper = mapper;
        }


        public async Task<PrivateUser> GetLoginByCredentials(UserLogin login)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            var list = await base.GetAllAsync();
            PrivateUser result = null;

            if (login.Email is not null)
            {
              
                 result = list.FirstOrDefault(x => x.Email == login.Email);
            }
            else if( login.Phone is not null)
            {
                 result = list.FirstOrDefault(x => x.PhoneNumber == login.Phone);
            }
            
           

            return result;
        }

        public async Task<PrivateUser> RegisterUser(UserSignUp security)
        {
            var map = _mapper.Map<PrivateUser>(security);
               return await base.CreateAsync(map);

        }
    }
}
