using AutoMapper;
using LPH.Core.Entities;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LPH.Core.Enumerations;
using LPH.Core.Exceptions;
using LPH.Core.Validations;

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
        internal readonly IValidatorService<TEntity> _val;
        /// <summary>
        /// Clase generica base que contiene toda la logica de interaccion de las entidades DTO del negocio de la API LPH.
        /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
        /// <typeparamref name="TEntity"/>  
        /// </summary>
        /// <param Nombre="Repository">Contiene la logica y conexion a la base de datos.</param>
        /// <param Nombre="mapper">Se encarga de mappear las propiedades entre entidades de negocio y Dtos.</param>
        public GenericDTOsController(IRepository<TEntity> Repository, IMapper mapper, IAuthorizationService authorizationService, IValidatorService<TEntity> val)
        {
            _Repository = Repository;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _val = val;
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
            
                var result = await _Repository.FindAsync(t => t.Id == id);
                if (!_val.Execute(result,Operation.Delete))
                {
                    throw new ValidationException($"{typeof(TEntity).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas", _val.Disapprobed);
                }
                await _Repository.DeleteAsync(result);


                return Ok(new { message = true });
          

        }
        /// <summary>
        /// Obtiene toda la informacion solicitada a la API de una entidad Dto en concreto.
        /// </summary>
        /// <returns></returns>
#if !DEBUG
        [Authorize]
#endif
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public virtual async Task<IActionResult> Get()
        {
            
                var result = await _Repository.GetAllAsync();

                List<TEntityDto> resulList = new List<TEntityDto>();

                foreach (var item in result)
                {
                    var entityMapper = _mapper.Map<TEntityDto>(item);
                    resulList.Add(entityMapper);
                }

               // var resultMapper = _mapper.Map<ICollection<TEntityDto>>(result);


                return Ok(resulList);
           


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


            var result = await _Repository.FindAsync(t => t.Id == id);

            if (!_val.Execute(result, Core.Enumerations.Operation.GetId))
            {
                throw new ValidationException($"{typeof(TEntity).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas", _val.Disapprobed);
            }

            var resultMapper = _mapper.Map<TEntityDto>(result);

            return Ok(resultMapper);






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

           
                var resultMapper = _mapper.Map<TEntity>(administer);

            if (!_val.Execute(resultMapper,Operation.Post))
            {
                throw new ValidationException($"{typeof(TEntity).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas", _val.Disapprobed);
            }
                
                var result = await _Repository.CreateAsync(resultMapper);
                var response = _mapper.Map<TEntity>(result);

                return Ok(response);
           

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
           

                var resultEn = await _Repository.FindAsync(e => e.Id == entity.Id);

                if (!_val.Execute(resultEn,Operation.Put))
                {
                    throw new  ValidationException($"{typeof(TEntity).Name} tiene uno o mas errores de validacion, revisar validaciones no aprobadas", _val.Disapprobed);
                }
                var resultMapper = _mapper.Map<TEntity>(entity);
                if (resultEn is LPH.Core.Entities.Usuario)
                {
                    (resultMapper as Usuario).Password = (resultEn as Usuario).Password;
                }


                var result = await _Repository.UpdateAsync(resultMapper);
                var update = _mapper.Map<TEntityDto>(result);


                return Ok(update);
           
        }
    }
}