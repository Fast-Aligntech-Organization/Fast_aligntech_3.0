using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LPH.Api.Responses;
using LPH.Core.DTOs;
using LPH.Core.Entities;
using LPH.Core.Enumerations;
using LPH.Core.Interfaces; 
using System.Threading.Tasks;
using System;

using Microsoft.Data.SqlClient;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace LPH.Api.Controllers.SecurityControllers
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
        [ProducesResponseType(typeof(UsuarioDto),StatusCodes.Status201Created)]
        
        public async Task<IActionResult> Post(UsuarioSignUp security)
        {

            try
            {
              

                string password = security.Password;

                security.Password = _passwordService.Hash(security.Password);
                await _securityService.RegisterUser(_mapper.Map<Usuario>(security));

                var created = await   _securityService.GetLoginByCredentials(new UserLogin() { Contraseña = password, Email = security.Email });

                var dto = _mapper.Map<UsuarioDto>(created);

                return Created(new Uri($"api/users/{created.Id}"), dto);




            }
           
            catch(Exception err)
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