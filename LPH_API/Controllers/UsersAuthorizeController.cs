using LPH.Core.Entities;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LPH.Api.Controllers
{
    [NonController]
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsersAuthorizeController : GenericController<Usuario>
    {
        public UsersAuthorizeController(IRepository<Usuario> Repository, IService<Usuario> service, IWebHostEnvironment enviroment) : base(Repository, service, enviroment)
        {
        }
    }
}
