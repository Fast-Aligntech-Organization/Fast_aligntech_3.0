using LPH.Api.Controllers;
using LPH.Core.Entities;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LPH.API.Controllers
{
    [NonController]
    //[Route("api/[controller]")]
    //[ApiController]
    public class OrdersAuthorizeController : GenericController<Orden>
    {
        public OrdersAuthorizeController(IRepository<Orden> Repository, IValidatorService<Orden> service, IWebHostEnvironment enviroment) : base(Repository, service, enviroment)
        {
        }

        // GET: MuralOrderController


    }
}
