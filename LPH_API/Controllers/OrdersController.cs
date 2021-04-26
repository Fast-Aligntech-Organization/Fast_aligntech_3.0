using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPH.Api.Controllers;
using LPH.Core.DTOs;
using LPH.Core.Entities;
using LPH.Core.Interfaces;
using AutoMapper;
using LPH.Api.Responses;
using Microsoft.AspNetCore.Authorization;
using LPH.Api.Filters;
namespace LPH.Api.Controllers
{
    /// <summary>
    /// Administra toda la logica de las ordenes
    /// </summary>
    [Route("api/[controller]")] 
   
    [ApiController]
    public class OrdersController : GenericDTOsController<Orden, OrdenDto>
    {
        public OrdersController(IRepository<Orden> Repository, IMapper mapper, IAuthorizationService authorizationService) : base(Repository, mapper, authorizationService)
        {
        }



        /// <summary>
        /// Devuelve los comentarios por orden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}/comments")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(OrdenCommentDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Comments(int id)
        {
             
            try
            {
                var result = await _Repository.FindAsync(o => o.Id == id);

                if (result == null)
                {

                    return NotFound($"La orden con el Id: {id} no existe");
                }

                var commentsdto = _mapper.Map<IList<OrdenCommentDto>>(result.Comments.ToList());

               
                return Ok(commentsdto);

            }
            catch (Exception err)
            {


                if (err.InnerException != null)
                {
                   return BadRequest($"Error: {err.Message}\n Inner Error: {err.InnerException.Message}");
                }
                else
                {
                     return BadRequest($"Error: {err.Message} ");
                }
            }


        }

        /// <summary>
        /// Obtiene toda la informacion solicitada a la API de una entidad Orden.
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        [ProducesResponseType(statusCode: StatusCodes.Status200OK,type: typeof(List<OrdenDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Get()
        {
            return await base.Get();
        }

        /// <summary>
        /// Obtiene toda la informacion solicitada a la API de una entidad Orden por medio de su Id
        /// No requiere permisos especiales
        /// </summary>
        /// <param Nombre="id">Numero unico de identificacion para cada Entidad.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK,type:typeof(OrdenDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Get(int id)
        {
            return await base.Get(id);
        }
        /// <summary>
        /// [Authorize]
        /// Da de alta una orden nueva generada por un usuario;
        /// Una orden solo podra ser creada por un usuario registrada, se requiere token
        /// </summary>
        /// <param Nombre="administer">Entidad a agregar</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]        
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Post(OrdenDto administer)
        {
            return await base.Post(administer);
        }
        /// <summary>
        /// [Authorize]
        /// Actualiza una Orden existente.
        /// La orden solo podra ser actualizada por el usuario que la creo
        /// para eso se requiere pasar el Token 
        /// </summary>
        /// <param Nombre="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [OwnerOrden]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(OrdenDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Put(OrdenDto entity)
        {
            return await base.Put(entity);
        }
        /// <summary>
        /// [Authorize]
        /// Elimina una orden por su Id.
        /// La orden solo podra ser Eliminada por el usuario que la creo o por el administrador
        /// para eso se requiere pasar el Token
        /// </summary>
        /// <param Nombre="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
        [HttpDelete("{id}")]
        [Authorize]
        [OwnerOrden]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK,type: typeof(bool))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
