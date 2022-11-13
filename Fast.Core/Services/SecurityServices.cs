﻿using Fast.Core.Entities;
using Fast.Core.Interfaces;
using System.Threading.Tasks;


namespace Fast.Core.Services
{
    public class SecurityServices : ISecurityService
    {
        private readonly ISecurityRepositor _repository;

        public SecurityServices(ISecurityRepositor unitOfWork)
        {
            _repository = unitOfWork;
        }

        public async Task<Usuario> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _repository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Usuario security)
        {
            await _repository.RegisterUser(security);
        }
    }
}
