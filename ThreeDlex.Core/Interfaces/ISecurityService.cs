using ThreeDlex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreeDlex.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<User> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(User security);
    }
}
