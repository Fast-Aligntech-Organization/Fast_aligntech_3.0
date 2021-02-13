using Microsoft.AspNetCore.Mvc;
using LPH.Api.Responses;
using LPH.Core.Exceptions;
using LPH.Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;


namespace LPH.Api.Controllers
{
    /// <summary>
    /// Clase generica base que contiene toda la logica de interaccion de las entidades del negocio de la API LPH.
    /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
    /// </summary>
    /// <typeparam name="TEntity">Entidad de negocio, esta debe ser una clase y poder ser instanciada, ademas implementar la interfaz <see cref="IEntity"/>.</typeparam>
    [Authorize]
    [ApiController]
    public class GenericController<TEntity> : ControllerBase, IController<TEntity> where TEntity : class,IEntity, new()
    {

        internal readonly IRepository<TEntity> _Repository;
        internal readonly IService<TEntity> _service;
        internal readonly IWebHostEnvironment _enviroment;

        /// <summary>
        /// Clase generica base que contiene toda la logica de interaccion de las entidades del negocio de la API LPH.
        /// </summary>
        /// <param name="Repository">Contiene la logica y conexion a la base de datos</param>
        /// <param name="service">Contiene servicios para la comprobacion de las correctas especificaciones y restricciones delas entidades</param>
        public GenericController(IRepository<TEntity> Repository, IService<TEntity> service, IWebHostEnvironment enviroment)
        {
            _Repository = Repository;
            _service = service;
            _enviroment = enviroment;

            
        }

        /// <summary>
        /// Obtiene toda la informacion solicitada a la API de una entidad en concreto.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {

            var result = await _Repository.GetAllAsync();
            var lis = result.ToList();
            var response = new ApiResponse(lis);

            return Ok(response);
        }

        /// <summary>
        /// Obtiene la informacion de una entidad por su Id.
        /// </summary>
        /// <param name="id">Numero unico de identificacion para cada Entidad.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {



            var result = await _Repository.FindAsync(t => t.Id == id);
            if (_service.ExecuteAllValidator(result, Core.Enumerations.Operation.GetId))
            {
                var response = new ApiResponse(result);


                return Ok(response);
            }
            else
            {
                throw new BusisnessException($"Ningun usuario con el Id : {id}") { Details = _service.Disapprobed, Status = (int)HttpStatusCode.NotFound };
            }



        }

        /// <summary>
        /// Agrega una entidad nueva a la coleccion correspondiente.
        /// </summary>
        /// <param name="entity">Entidad a agregar</param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntity entity)
        {
            if (_service.ExecuteAllValidator(entity, Core.Enumerations.Operation.Post))
            {
               var result = await _Repository.CreateAsync(entity);
                var response = new ApiResponse(result);

                _service.ClearResults();
                return Ok(response);
            }
            else
            {
                throw new BusisnessException() { Details = _service.Disapprobed, Status = (int)HttpStatusCode.BadRequest };
            }

        }

        /// <summary>
        /// Elimina una entidad por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var result = await _Repository.FindAsync(t => t.Id == id);
            if (_service.ExecuteAllValidator(result, Core.Enumerations.Operation.Delete))
            {
                await _Repository.DeleteAsync(result);
                var response = new ApiResponse(true);

            return Ok(response);
            }
            else
            {
                throw new BusisnessException() { Details = _service.Disapprobed, Status = (int)HttpStatusCode.BadRequest };
            }


        }

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        public virtual async Task<IActionResult> Put(TEntity entity)
        {

            if (_service.ExecuteAllValidator(entity, Core.Enumerations.Operation.Put))
            {
                var result = await _Repository.UpdateAsync(entity);
            var response = new ApiResponse(result);
            return Ok(response);
            }
            else
            {
                throw new BusisnessException() { Details = _service.Disapprobed, Status = (int)HttpStatusCode.BadRequest };
            }
        }

        //[NonAction]
        //public string SaveFile(IFormFile file, string path)
        //{
        //    string name = Path.GetRandomFileName();


        //}


    }
}
