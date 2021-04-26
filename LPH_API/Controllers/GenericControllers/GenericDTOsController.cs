using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LPH.Api.Responses;
using LPH.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using LPH.Core.Entities;

namespace LPH.Api.Controllers
{
    /// <summary>
    /// Clase generica base que contiene toda la logica de interaccion de las entidades DTO del negocio de la API LPH.
    /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
    /// 
    /// </summary>
    /// <typeparam Nombre="TEntity">Entidad de negocio</typeparam>
    /// <typeparam Nombre="TEntityDto">Entidad Dto protegida del negocio</typeparam>
    [ApiController]
    public class GenericDTOsController<TEntity, TEntityDto> : ControllerBase, IController<TEntityDto> where TEntity : class, IEntity, new() where TEntityDto : class, IEntity, new()
    {

       internal readonly IRepository<TEntity> _Repository;
        internal readonly IAuthorizationService _authorizationService;
       internal readonly IMapper _mapper;
        /// <summary>
        /// Clase generica base que contiene toda la logica de interaccion de las entidades DTO del negocio de la API LPH.
        /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
        /// <typeparamref name="TEntity"/>  
        /// </summary>
        /// <param Nombre="Repository">Contiene la logica y conexion a la base de datos.</param>
        /// <param Nombre="mapper">Se encarga de mappear las propiedades entre entidades de negocio y Dtos.</param>
        public GenericDTOsController(IRepository<TEntity> Repository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _Repository = Repository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        /// <summary>
        /// Elimina una entidad por su Id.
        /// </summary>
        /// <param Nombre="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
#if !DEBUG
         [Authorize]
#endif
        [HttpDelete]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _Repository.FindAsync(t => t.Id == id);
                if (result == null)
                {
                    return NotFound($"{typeof(TEntity).Name} con el Id: {id} no existe ");
                }
                await _Repository.DeleteAsync(result);


                return Ok(true);
            }
            catch (System.Exception err)
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
        /// Obtiene toda la informacion solicitada a la API de una entidad Dto en concreto.
        /// </summary>
        /// <returns></returns>
        #if !DEBUG
        [Authorize]
        #endif
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK )]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Get()
        {
            try
            {
                var result = await _Repository.GetAllAsync();
                var resultMapper = _mapper.Map<IEnumerable<TEntityDto>>(result);
               

                return Ok(resultMapper);
            }
            catch (System.Exception err)
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
        /// Obtiene la informacion de una entidad por su Id.
        /// </summary>
        /// <param Nombre="id">Numero unico de identificacion para cada Entidad.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _Repository.FindAsync(t => t.Id == id);



                if (result == null)
                {
                    return NotFound($"{typeof(TEntity).Name} con el Id: {id} no existe ");
                }

                //var authorizationResult = await _authorizationService.AuthorizeAsync(User, result, new PropertyOrAdministerRequirement());
                //if (authorizationResult.Succeeded)
                //{

                //    var resultMapper = _mapper.Map<TEntityDto>(result);

                //    return Ok(resultMapper);
                //}
                //else
                //{
                //    return Unauthorized("El token proporcionado no tiene permiso para acceder a la informacion solicitada");
                //}


                var resultMapper = _mapper.Map<TEntityDto>(result);

                return Ok(resultMapper);




            }
            catch (System.Exception err)
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
        /// Agrega una entidad nueva a la coleccion correspondiente.
        /// </summary>
        /// <param Nombre="administer">Entidad a agregar</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Post(TEntityDto administer)
        {

            try
            {
                var resultMapper = _mapper.Map<TEntity>(administer);
                var result = await _Repository.CreateAsync(resultMapper);
                var response = _mapper.Map<TEntity>(result);

                return Ok(response);
            }
            catch (System.Exception err)
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
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param Nombre="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [HttpPut()]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Put(TEntityDto entity)
        {
            try
            {

                var resultEn = await _Repository.FindAsync(e => e.Id == entity.Id);

                if (resultEn == null)
                {
                     return NotFound($"{typeof(TEntity).Name} con el Id: {entity.Id} no existe ");
                }
                var resultMapper = _mapper.Map<TEntity>(entity);
                if (resultEn is LPH.Core.Entities.Usuario )
                {
                    (resultMapper as Usuario).Password = (resultEn as Usuario).Password;


                }
               

                var result = await _Repository.UpdateAsync(resultMapper);
                var update = _mapper.Map<TEntityDto>(result);
               

                return Ok(update);
            }
            catch (System.Exception err)
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
    }
}