using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core
{
    public interface ISecurityService
    {
        Task<PrivateUser> GetLoginByCredentials(UserLogin userLogin);
        Task<bool> RegisterUser(UserSignUp user);
    }
}
