using LPH.Api.Responses;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LPH.Api.Controllers
{
    /// <summary> 
    /// Clase generica base que contiene toda la logica de interaccion de las entidades del negocio de la API LPH.
    /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
    /// </summary>
    /// <typeparam Nombre="TEntity">Entidad de negocio, esta debe ser una clase y poder ser instanciada, ademas implementar la interfaz <see cref="IEntity"/>.</typeparam>
    [Authorize(Roles = "Administrador")]

    [ApiController]
    public class GenericController<TEntity> : ControllerBase, IController<TEntity> where TEntity : class, IEntity, new()
    {

        internal readonly IRepository<TEntity> _Repository;
        internal readonly IService<TEntity> _service;
        internal readonly IWebHostEnvironment _enviroment;

        /// <summary>
        /// Clase generica base que contiene toda la logica de interaccion de las entidades del negocio de la API LPH.
        /// </summary>
        /// <param Nombre="Repository">Contiene la logica y conexion a la base de datos</param>
        /// <param Nombre="service">Contiene servicios para la comprobacion de las correctas especificaciones y restricciones delas entidades</param>
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
        [Authorize]
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponse))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Get()
        {


            try
            {
                var result = await _Repository.GetAllAsync();
                var lis = result.ToList();
                var response = new ApiResponse(lis);

                return Ok(response);
            }
            catch (System.Exception err)
            {

                if (err.InnerException != null)
                {
                    return BadRequest(new { message = $"Error: {err.Message}\n Inner Error: {err.InnerException.Message}" });
                }
                else
                {
                    return BadRequest(new { message = $"Error: {err.Message} " });
                }
            }


        }

        /// <summary>
        /// Obtiene la informacion de una entidad por su Id.
        /// </summary>
        /// <param Nombre="id">Numero unico de identificacion para cada Entidad.</param>
        /// <returns></returns>
        [HttpGet("{id}")]

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponse))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Get(int id)
        {

            try
            {
                var result = await _Repository.FindAsync(t => t.Id == id);

                if (_service.ExecuteAllValidator(result, Core.Enumerations.Operation.GetId))
                {
                    var response = new ApiResponse(result);


                    return Ok(response);
                }
                else
                {

                    return NotFound(new { message = $"{typeof(TEntity).Name} con el Id: {id} no existe " });

                }
            }
            catch (System.Exception err)
            {

                return BadRequest(err);
            }





        }

        /// <summary>
        /// Agrega una entidad nueva a la coleccion correspondiente.
        /// </summary>
        /// <param Nombre="entity">Entidad a agregar</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(ApiResponse))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Post(TEntity entity)
        {
            try
            {

                var result = await _Repository.CreateAsync(entity);
                var response = new ApiResponse(result);

                _service.ClearResults();
                return Ok(response);

            }

            catch (System.Exception err)
            {
                return BadRequest(err.InnerException.Message);
            }

        }

        /// <summary>
        /// Elimina una entidad por su Id.
        /// </summary>
        /// <param Nombre="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponse))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {

                var result = await _Repository.FindAsync(t => t.Id == id);

                if (result == null)
                {
                    return NotFound(new { message = $"{typeof(TEntity).Name} con el Id: {id} no existe " });
                }

                await _Repository.DeleteAsync(result);
                var response = new ApiResponse(true);

                return Ok(response);
            }
            catch (System.Exception err)
            {


                if (err.InnerException != null)
                {
                    return BadRequest(new { message = $"Error: {err.Message}\n Inner Error: {err.InnerException.Message}" });
                }
                else
                {
                    return BadRequest(new { message = $"Error: {err.Message} " });
                }
            }



        }

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param Nombre="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [HttpPut]

        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponse))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Put(TEntity entity)
        {


            try
            {


                var result = await _Repository.UpdateAsync(entity);
                if (result == null)
                {
                    return NotFound(new { message = $"{typeof(TEntity).Name} con el Id: {entity.Id} no existe " });
                }
                var response = new ApiResponse(result);
                return Ok(response);
            }
            catch (System.Exception err)
            {


                if (err.InnerException != null)
                {
                    return BadRequest(new { message = $"Error: {err.Message}\n Inner Error: {err.InnerException.Message}" });
                }
                else
                {
                    return BadRequest(new { message = $"Error: {err.Message} " });
                }
            }



        }


        // internal bool IsSameUser(int id,bool administerImport = true)
        //{
        //     var sid = HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Sid);



        //    if (administerImport)
        //    {
        //        var role = HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Role);

        //        if (role.Value == Enum.GetName<RoleType>(RoleType.Administrator))
        //        {
        //            return true;
        //        }

        //    }

        //    if (sid == null)
        //    {

        //    }

        //}

        //[NonAction]
        //public string SaveFile(IFormFile file, string path)
        //{
        //    string Nombre = Path.GetRandomFileNombre();


        //}




    }
}
