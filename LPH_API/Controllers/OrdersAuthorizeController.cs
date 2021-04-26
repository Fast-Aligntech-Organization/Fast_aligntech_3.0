using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPH.Api.Controllers;
using LPH.Core.Entities;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace LPH.API.Controllers
{
    [NonController]
    //[Route("api/[controller]")]
    //[ApiController]
    public class OrdersAuthorizeController : GenericController<Orden>
    {
        public OrdersAuthorizeController(IRepository<Orden> Repository, IService<Orden> service, IWebHostEnvironment enviroment) : base(Repository, service, enviroment)
        {
        }

        // GET: MuralOrderController
      
      
    }
}
