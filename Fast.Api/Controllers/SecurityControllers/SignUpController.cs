using AutoMapper;
using Fast.Core.DTOs;
using Fast.Core.Entities;
using Fast.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fast.Api.Controllers.SecurityControllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SignUpController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
          
        }
        /// <summary>
        /// Registra un usuario nuevo 
        /// </summary>
        /// <param name="security"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDto), StatusCodes.Status201Created)]

        public async Task<IActionResult> Post(UsuarioSignUp security)
        {

            try
            {


                string password = security.Password;

                security.Password = _passwordService.Hash(security.Password);
                security.Role = Core.Enumerations.RoleType.User;
                await _securityService.RegisterUser(_mapper.Map<Usuario>(security));

                var created = await _securityService.GetLoginByCredentials(new UserLogin() { Contraseña = password, Email = security.Email });

                var dto = _mapper.Map<UsuarioDto>(created);

                var uri = $"{Request.Scheme}{@"://"}{Request.Host}/users/{dto.Id}";

                return Created(uri, dto);




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



    }
}