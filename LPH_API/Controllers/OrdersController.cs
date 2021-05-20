using AutoMapper;
using LPH.Api.Filters;
using LPH.Core.DTOs;
using LPH.Core.Entities;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using File = LPH.Core.Entities.File;

namespace LPH.Api.Controllers
{
    /// <summary>
    /// Administra toda la logica de las ordenes
    /// </summary>
    [Route("api/[controller]")]

    [ApiController]
    public class OrdersController : GenericDTOsController<Orden, OrdenDto>
    {
        IConfiguration _configuration;
        IRepository<File> _fileRepository;

        public OrdersController(IRepository<Orden> Repository, IRepository<File> fileRepository, IConfiguration configuration, IMapper mapper, IAuthorizationService authorizationService) : base(Repository, mapper, authorizationService)
        {
            _configuration = configuration;
            _fileRepository = fileRepository;
        }
        /// <summary>
        /// [Authorize]
        /// Sube una imagen ligada a una orden.
        /// solo el usuario puede realizar modificaciones sobre su propia orden
        /// </summary>
        /// <param name="id"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [Authorize]
        [OwnerUser]
        [HttpPost("{id}/uploadImage")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadImage(int id, IFormFile file)
        {




            try
            {

                string extJson = _configuration["Extensions:Images"];
                string[] extensions = extJson.Split(",");

                var order = await _Repository.FindAsync(o => o.Id == id);

                if (order == null)
                {

                    return NotFound(new { message = $"La orden con el Id {id} no existe!" });


                }



                if (file != null && file.Length > 0)
                {


                    if (file.Length <= 1024*1024*5)
                    {
                        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();


                        if (extensions.Contains(ext))
                        {

                            var filename = Path.GetRandomFileName() + ext;


                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\orden", filename);

                            string relativePath = string.Concat(@"wwwroot\images\orden\", filename);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }


                            File f1 = new File();

                            f1.Extencion = ext;
                            f1.IdOrden = id;
                            f1.SizeFile = file.Length;
                            f1.FileName = filename;
                            f1.UriString = relativePath;

                            order.Files.Add(f1);
                            var result = await _Repository.UpdateAsync(order);



                            // await _Repository.UpdateAsync(order);

                            return Ok(new { message = true });

                        }
                        else
                        {
                            return BadRequest(new { message = $"La extencion de archivo no es valida: {ext}" });
                        } 
                    }
                    else
                    {
                        return BadRequest(new { message = "La imagen no puede pesar mas de 5 MB!" });
                    }


                }
                else
                {
                    return BadRequest(new { message = "El archivo no es valido o se encuentra vacio" });
                }


            }
            catch (Exception err)
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

                    return NotFound(new { message = $"La orden con el Id: {id} no existe" });
                }

                var commentsdto = _mapper.Map<IList<OrdenCommentDto>>(result.Comments.ToList());


                return Ok(commentsdto);

            }
            catch (Exception err)
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
        /// Obtiene toda la informacion solicitada a la API de una entidad Orden.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(List<OrdenDto>))]
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
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(OrdenDto))]
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
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(bool))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
