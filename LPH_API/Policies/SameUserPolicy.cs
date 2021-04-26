using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPH.Core.Interfaces;
using LPH.Infrastructure.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace LPH.Api.Controllers
{
    public class SameUserFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = context.Controller as ControllerBase;



            if (!controller.User.HasClaim(c => c.Type == ClaimTypes.Sid))
            {
                 context.Result = new JsonResult(new
                {
                    StatusCode = StatusCodes.Status403Forbidden,
                    Value = "Token invalido"

                });
                return;
            }

           var claim =  controller.User.FindFirst(ClaimTypes.Sid);

            if (claim == null)
            {
                context.Result = new JsonResult(new
                {
                    StatusCode = StatusCodes.Status403Forbidden,
                    Value = "Token invalido"

                });
                return;
            }

            object id;
          bool Existid = controller.Request.RouteValues.TryGetValue("id",out id);

            if (id == null)
            {
                context.Result = new JsonResult(new
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Value = "No se a proporcionado un Id valido"
                
                });
                return;
            }

            if ((int)id != Convert.ToInt32(claim.Value))
            {
             
                context.Result = new JsonResult(new
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Value = "No tienes autorizacion para realizar operaciones sobre este usuario"

                });
                return;
            }
            


        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
