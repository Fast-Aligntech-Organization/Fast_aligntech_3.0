using AutoMapper;
using LPH.Api.Filters;
using LPH.Core.DTOs;
using LPH.Core.Entities;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LPH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : GenericDTOsController<OrdenComment, OrdenCommentDto>
    {
        public CommentsController(IRepository<OrdenComment> Repository, IMapper mapper, IAuthorizationService authorizationService) : base(Repository, mapper, authorizationService)
        {
        }


        /// <summary>
        /// Obtiene todos los comentarios
        /// No requiere permisos especiales
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<OrdenCommentDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Get()
        {
            return await base.Get();
        }

        /// <summary>
        /// Obtiene un comentario por el Id.
        /// No requiere permisos especiales
        /// </summary>
        /// <returns></returns> 


        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(OrdenCommentDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> Get(int id)
        {
            return await base.Get(id);
        }


        /// <summary>
        /// [Authorize]
        /// Crea un nuevo comentario generado por un usuario;
        /// Se requiere token
        /// </summary>
        /// <param Nombre="administer">Entidad a agregar</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> Post(OrdenCommentDto administer)
        {
            return await base.Post(administer);
        }

        /// <summary>
        /// [Authorize]
        /// Actualiza un comentario.
        /// Se requerira Token para acceder a la informacion, Ademas solo un usuario administrador o el propio
        /// usuario tendra accesso a modificar la informacion
        /// </summary>
        /// <param Nombre="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [Authorize]
        [OwnerComment]
        [HttpPut()]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(OrdenCommentDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Put(OrdenCommentDto entity)
        {
            return await base.Put(entity);
        }
        /// <summary>
        /// [Authorize]
        /// Elimina un comentario por su Id.
        /// Un comentario solo podra ser eliminado por el usuario que lo creo o por el administrador
        /// Ee requiere pasar el Token
        /// </summary>
        /// <param Nombre="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        [OwnerComment]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(bool))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }






    }
}
