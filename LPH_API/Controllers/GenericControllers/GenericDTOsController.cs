using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using LPH.Api.Responses;
using LPH.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace LPH.Api.Controllers
{
    /// <summary>
    /// Clase generica base que contiene toda la logica de interaccion de las entidades DTO del negocio de la API LPH.
    /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
    /// </summary>
    /// <typeparam name="TEntity">Entidad de negocio</typeparam>
    /// <typeparam name="TEntityDto">Entidad Dto protegida del negocio</typeparam>
    [ApiController]
    public class GenericDTOsController<TEntity, TEntityDto> : ControllerBase, IController<TEntityDto> where TEntity : class, IEntity, new() where TEntityDto : class, IEntity, new()
    {

        private readonly IRepository<TEntity> _Repository;
        private readonly IMapper _mapper;
        /// <summary>
        /// Clase generica base que contiene toda la logica de interaccion de las entidades DTO del negocio de la API LPH.
        /// Su implementacion con un tipo concreto debe ser establecidad para su correcto funcionamiento.
        /// </summary>
        /// <param name="Repository">Contiene la logica y conexion a la base de datos.</param>
        /// <param name="mapper">Se encarga de mappear las propiedades entre entidades de negocio y Dtos.</param>
        public GenericDTOsController(IRepository<TEntity> Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Elimina una entidad por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelbe el resultado de la operacion solicitada.</returns>
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _Repository.FindAsync(t => t.Id == id);
            await  _Repository.DeleteAsync(result);
            var response = new ApiResponse(true);

            return Ok(response);
        }
        /// <summary>
        /// Obtiene toda la informacion solicitada a la API de una entidad Dto en concreto.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await _Repository.GetAllAsync();
            var resultMapper = _mapper.Map<IEnumerable<TEntityDto>>(result);
            var response = new ApiResponse(resultMapper);

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
            var resultMapper = _mapper.Map<TEntityDto>(result);
            var response = new ApiResponse(resultMapper);

            return Ok(response);
        }
        /// <summary>
        /// Agrega una entidad nueva a la coleccion correspondiente.
        /// </summary>
        /// <param name="administer">Entidad a agregar</param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<IActionResult> Post(TEntityDto administer)
        {
            var resultMapper = _mapper.Map<TEntity>(administer);
            var result = await _Repository.CreateAsync(resultMapper);
            var response = new ApiResponse(result);

            return Ok(response);

        }
        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(TEntityDto entity)
        {
            var resultMapper = _mapper.Map<TEntity>(entity);

            var result = await _Repository.UpdateAsync(resultMapper);
            var response = new ApiResponse(result);

            return Ok(response);
        }
    }
}