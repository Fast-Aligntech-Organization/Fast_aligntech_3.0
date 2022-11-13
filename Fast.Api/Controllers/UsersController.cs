using AutoMapper;
using Fast.Api.Filters;
using Fast.Core.DTOs;
using Fast.Core.Entities;
using Fast.Core.Exceptions;
using Fast.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fast.Api.Controllers
{
    /// <summary>
    /// Administra toda la logica de los usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : GenericDTOsController<Usuario, UsuarioDto>
    {

        private readonly ISecurityService _securityService;

        private readonly IPasswordService _passwordService;

        public UsersController(IRepository<Usuario> Repository,
                               IMapper mapper,
                               ISecurityService securityService,
                               IPasswordService passwordService, IAuthorizationService authorizationService, IValidatorService<Usuario> val) : base(Repository, mapper, authorizationService,val)
        {
            _securityService = securityService;
            _passwordService = passwordService;
        }



        /// <summary>
        /// [Authorize]
        /// Obtiene todos los usuarios registrados 
        /// Se requerira Token para acceder a la informacion, Ademas solo un usuario administrador podra
        /// obtener acceso a toda la informacion de los usuarios
        /// </summary>
        /// <returns></returns>
        [Authorize]

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<UsuarioDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> Get()
        {
            return await base.Get();
        }

        /// <summary>
        /// [Authorize]
        /// Obtiene el usuario por el Id.
        /// Se requerira Token para acceder a la informacion, Ademas solo un usuario administrador o el propio
        /// usuario tendra accesso a la informacion
        /// </summary>
        /// <returns></returns> 
        [Authorize]
        [OwnerUser]
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(UsuarioDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> Get(int id)
        {



            return await base.Get(id);


        }

        /// <summary>
        /// Obtiene el usuario por el GoogleUUID;
        /// </summary>
        /// <returns></returns> 
        [HttpGet("/byuuid/{uuid}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(UsuarioDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public  async Task<IActionResult> GetGoogleUUID(string uuid)
        {
            
            var result = await _Repository.FindAsync(t => t.GoogleUUID.ToString() == uuid);

            if (!_val.Execute(result, Core.Enumerations.Operation.Custom))
            {
                throw new ValidationException($"{typeof(Usuario).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas");
            }




            var resultMapper = _mapper.Map<UsuarioDto>(result);

                return Ok(resultMapper);
        }


        /// <summary>
        /// [Authorize]
        /// Crea un nuevo usuario
        /// obtener acceso a toda la informacion de los usuarios
        /// </summary>
        /// <returns></returns>    
       // [NonAction]
        public override async Task<IActionResult> Post(UsuarioDto entity)
        {
            return await base.Post(entity);
        }

        /// <summary>
        /// [Authorize]
        /// Actualiza la informacion de un usuario.
        /// Se requerira Token para acceder a la informacion, Ademas solo un usuario administrador o el propio
        /// usuario tendra accesso a modificar la informacion
        /// </summary>
        /// <param Nombre="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [Authorize]
        [OwnerUser]
        [HttpPut()]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(UsuarioDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Put(UsuarioDto entity)
        {

            var result = await _Repository.FindAsync(e => e.Id == entity.Id);
            if (!_val.Execute(result, Core.Enumerations.Operation.Put))
            {
                throw new ValidationException($"{typeof(Usuario).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas");
            }
            else
            {
                if (result.Role == Core.Enumerations.RoleType.Administrator || result.Role == Core.Enumerations.RoleType.Programmer)
                {
                    return await base.Put(entity);
                }
                else
                {
                    entity.Role = Core.Enumerations.RoleType.User;
                    return await base.Put(entity);
                }
            }


           
        }

        /// <summary>
        /// [Authorize]
        /// Elimina un usuario por su Id.
        /// Se requerira Token para acceder a la informacion, Ademas solo un usuario administrador o el propio
        /// usuario tendra accesso a eliminar su cuenta
        /// </summary>
        /// <param Nombre="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
        [Authorize]
        [OwnerUser]
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id) => await base.Delete(id);

        /// <summary>
        /// [Authorize]
        /// Unica forma de modificar la contraseña de un usuario;
        /// Se requerira Token para acceder a la informacion, Ademas solo un usuario administrador o el propio
        /// usuario tendra accesso a cambiar la contraseña
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        [Authorize]
        [OwnerUser]
        [HttpPut("{id}/changePassword")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(string))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> ChangePassword(int id, UserChangePassword password)
        {

           
                var result = await _Repository.FindAsync(t => t.Id == id);
                if (!_val.Execute(result, Core.Enumerations.Operation.Custom))
                {
                    throw new ValidationException($"{typeof(Usuario).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas");
                }

                if (!_passwordService.Check(result.Password, password.OldPassword))
                {
                    return Unauthorized(new { message = "Contraseña incorrecta!" });
                }

                string PHashNew = _passwordService.Hash(password.NewPassword);

                result.Password = PHashNew;

                _Repository.Update(result);


                return Ok(new { message = "Contraseña Actualizada!" });




        }


        /// <summary>
        /// Obtiene los comentarios que ha realizado un usuario en particular
        /// No requiere permisos especiales
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>La lista de comentarios y su calificacion</returns>
        [HttpGet, Route("{id}/comments")]
        [OwnerUser]//Verificamos que sea el mismo usuario
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<OrdenCommentDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Comments(int id)
        {
           

                var result = await _Repository.FindAsync(o => o.Id == id);

                if (!_val.Execute(result, Core.Enumerations.Operation.Custom))
                {
                    throw new ValidationException($"{typeof(Usuario).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas");
                }

                var orderslist = _mapper.Map<IList<OrdenCommentDto>>(result.Comments.ToList());





                return Ok(orderslist);
          

        }

        /// <summary>
        /// Obtiene las ordenes que un usuario en particular a pedido
        /// No requiere permisos especiales
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Una lista de ordenes</returns>
        [HttpGet, Route("{id}/orders")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<OrdenDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Orders(int id)
        {

            var result = await _Repository.FindAsync(o => o.Id == id);

            if (!_val.Execute(result, Core.Enumerations.Operation.Custom))
            {
                throw new ValidationException($"{typeof(Usuario).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas");
            }

            var orderslist = _mapper.Map<IList<OrdenDto>>(result.Ordenes.ToList());



            return Ok(orderslist);




        }




    }
}
