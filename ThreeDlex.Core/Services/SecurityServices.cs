using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ThreeDlex.Core.Entities;
using ThreeDlex.Core.Interfaces;


namespace ThreeDlex.Core.Services
{
   public class SecurityServices: ISecurityService
    {
        private readonly ISecurityRepositor _repository;

        public SecurityServices(ISecurityRepositor unitOfWork)
        {
            _repository = unitOfWork;
        }

        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _repository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(User security)
        {
            await _repository.RegisterUser(security);
        }
    }
}
