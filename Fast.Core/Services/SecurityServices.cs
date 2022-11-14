using Fast.Core;
using System.Threading.Tasks;


namespace Fast.Core.Services
{
    public class SecurityServices : ISecurityService
    {
        private readonly IAccountRepository _repository;

        public SecurityServices(IAccountRepository unitOfWork)
        {
            _repository = unitOfWork;
        }

        public async Task<PrivateUser> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _repository.GetLoginByCredentials(userLogin);
        }

        public async Task<bool> RegisterUser(UserSignUp user)
        {
            var privateUserResult = await _repository.RegisterUser(user);
            if (privateUserResult is not null) return true;
            
            return false;
           
        }

       
    }
}
