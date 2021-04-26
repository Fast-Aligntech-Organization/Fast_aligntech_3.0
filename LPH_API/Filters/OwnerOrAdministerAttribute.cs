using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using LPH.Core.DTOs;
using LPH.Core.Interfaces;
using LPH.Infrastructure.Repositories;
using LPH.Core.Entities;
using LPH.Core.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LPH.Api.Filters
{
    public class OwnerOrAdministerAttribute: ActionFilterAttribute
    {

        public Type TypeOfRepository { get; set; }

      


       

        public OwnerOrAdministerAttribute(Type typeOfRepository)
        {
            this.TypeOfRepository = typeOfRepository;
           

        }

        


       
       

        public override void OnActionExecuting(ActionExecutingContext context)
        {


            var sid  = context.HttpContext.User.FindFirst(ClaimTypes.Sid).Value;
            var role = context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            var idencabezado = context.HttpContext.Request.RouteValues["id"].ToString();
            var _repository = context.HttpContext.RequestServices.GetService(TypeOfRepository);
            var ActionParameter = context.ActionArguments;


            if (role == Enum.GetName(typeof(RoleType), RoleType.Administrator) || role == Enum.GetName(typeof(RoleType), RoleType.Programmer))
            {
                return;
            }

            if (_repository is IRepository<Usuario> )
            {
                var _userRepository = _repository as IRepository<Usuario>;

               

                if (!string.IsNullOrEmpty(idencabezado))
                {
                    if (sid == idencabezado)
                    {
                        return;
                    }
                    else
                    {
                        context.Result = new UnauthorizedObjectResult("");
                    }

                }

                else if(ActionParameter.Count > 0)
                {

                    var parameter = context.ActionArguments["entity"] as UsuarioDto;

                    if (parameter.Id.ToString() != sid)
                    {
                        context.Result = new UnauthorizedObjectResult("");
                    }
                    


                }
               





            }
          
            if(_repository is IRepository<Orden>)
            {
                var _ordenRepository = _repository as IRepository<Orden>;
                if (!string.IsNullOrEmpty(idencabezado))
                {

                    Orden orden = _ordenRepository.Find(o => o.IdUser.ToString() == idencabezado);

                    if (orden == null)
                    {
                        return;
                    }

                    if (sid == orden.IdUser.ToString())
                    {
                        return;
                    }
                    else
                    {
                        context.Result = new UnauthorizedObjectResult("No tienes autorizacion para modificar esta entidad!");
                    }

                }

                else if (ActionParameter.Count > 0)
                {

                    var parameter = context.ActionArguments["entity"] != null ? context.ActionArguments["entity"] as OrdenDto : context.ActionArguments["administer"] as OrdenDto;

                    Orden orden = _ordenRepository.Find(o => o.IdUser == parameter.Id);

                    if (orden.IdUser != parameter.IdUser)
                    {
                        context.Result = new UnauthorizedObjectResult("No puedes modificar el propietario de una entidad!");
                    }

                    if (parameter.IdUser.ToString() != sid)
                    {
                        context.Result = new UnauthorizedObjectResult("No tienes autorizacion para modificar esta entidad!");
                    }



                }

            }

            if (_repository is IRepository<OrdenComment>)
            {
                var _ordenRepository = _repository as IRepository<OrdenComment>;
                if (!string.IsNullOrEmpty(idencabezado))
                {

                    OrdenComment orden = _ordenRepository.Find(o => o.IdUser.ToString() == idencabezado);

                    if (orden == null)
                    {
                        return;
                    }

                    if (sid == orden.IdUser.ToString())
                    {
                        return;
                    }
                    else
                    {
                        context.Result = new UnauthorizedObjectResult("No tienes autorizacion para modificar esta entidad!");
                    }

                }

                else if (ActionParameter.Count > 0)
                {

                    var parameter = context.ActionArguments["entity"] != null ? context.ActionArguments["entity"] as OrdenCommentDto : context.ActionArguments["administer"] as OrdenCommentDto;

                    OrdenComment orden = _ordenRepository.Find(o => o.IdUser == parameter.Id);

                    if (orden.IdUser != parameter.IdUser)
                    {
                        context.Result = new UnauthorizedObjectResult("No puedes modificar el propietario de una entidad!");
                    }

                    if (parameter.IdUser.ToString() != sid)
                    {
                        context.Result = new UnauthorizedObjectResult("No tienes autorizacion para modificar esta entidad!");
                    }



                }

            }




        }


       


    }

     [System.AttributeUsage(AttributeTargets.Method)]
    public class OwnerOrdenAttribute : OwnerOrAdministerAttribute
    {
        public OwnerOrdenAttribute() : base(typeof(IRepository<Orden>))
        {
        }
    }

    public class OwnerUserAttribute : OwnerOrAdministerAttribute
    {
        public OwnerUserAttribute() : base(typeof(IRepository<Usuario>))
        {
        }
    }

    public class OwnerCommentAttribute : OwnerOrAdministerAttribute
    {
        public OwnerCommentAttribute() : base(typeof(IRepository<OrdenComment>))
        {
        }
    }
}
