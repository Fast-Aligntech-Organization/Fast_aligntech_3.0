using Fast.Core.Entities;
using Fast.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Fast.Api.Controllers
{
    [NonController]
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsersAuthorizeController : GenericController<Usuario>
    {
        public UsersAuthorizeController(IRepository<Usuario> Repository, IValidatorService<Usuario> service, IWebHostEnvironment enviroment) : base(Repository, service, enviroment)
        {
        }
    }
}
