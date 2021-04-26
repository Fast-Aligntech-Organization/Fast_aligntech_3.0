using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using LPH.Core.Entities;
using System.Security.Claims;
using LPH.Core.Enumerations;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LPH.Api.Controllers
{
    //public class PropertyOrAdministerAuthorizationHandler : AuthorizationHandler<PropertyOrAdministerRequirement,IEntity>
    //{
        

        

    //    HttpContext _httpContext;

    //    public PropertyOrAdministerAuthorizationHandler(HttpContext httpContext)
    //    {
    //        _httpContext = httpContext;
         
    //    }

      

    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PropertyOrAdministerRequirement requirement, IEntity resource)
    //    {
    //        var sid = context.User.FindFirst(ClaimTypes.Sid)?.Value;
    //        var role = context.User.FindFirst(ClaimTypes.Role)?.Value;
    //        var idencabezado = _httpContext.Request.RouteValues["id"].ToString();
    //        if (resource is Usuario)
    //        {
    //            if (sid == idencabezado|| role == Enum.GetName(typeof(RoleType), RoleType.Administrator) || role == Enum.GetName(typeof(RoleType), RoleType.Programmer))
    //            {
    //                context.Succeed(requirement);
    //            }

    //        }
    //        else if(resource is Orden)
    //        {
    //            var source = resource as Orden;
    //            if (sid == source.IdUser.ToString() || role == Enum.GetName(typeof(RoleType), RoleType.Administrator) || role == Enum.GetName(typeof(RoleType), RoleType.Programmer))
    //            {
    //                context.Succeed(requirement);
    //            }

    //        }
    //        else if( resource is OrdenComment)
    //        {
    //            var source = resource as OrdenComment;
    //            if (sid == source.IdUser.ToString() || role == Enum.GetName(typeof(RoleType), RoleType.Administrator) || role == Enum.GetName(typeof(RoleType), RoleType.Programmer))
    //            {
    //                context.Succeed(requirement);
    //            }

    //        }


          
    //        return Task.CompletedTask;

    //    }


    //}


    
}
