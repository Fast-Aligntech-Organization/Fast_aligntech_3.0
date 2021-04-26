using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using LPH.Core.Entities;

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
