using AutoMapper;
using LPH.Core.DTOs;
using LPH.Core.Entities;
using LPH.Core.Enumerations;
using LPH.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LPH.Api.Controllers
{
    /// <summary>
    /// Inicia sesion con el usuario especificado 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;
        private readonly IPasswordService _passwordService;
        private readonly IMapper _mapper;
        public LoginController(IConfiguration configuration, ISecurityService securityService, IPasswordService passwordService, IMapper mapper)
        {
            _configuration = configuration;
            _securityService = securityService;
            _passwordService = passwordService;
            _mapper = mapper;
        }

        /// <summary>
        /// Inicia session y Token necesario para acceder a los demas acciones
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(Token))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(UserLogin login)
        {

            try
            {

                var user = await _securityService.GetLoginByCredentials(login);

                if (user == null)
                {
                    return NotFound(new { message = $"No existe el usuario con el correo {login.Email}!" });
                }

                var validation = _passwordService.Check(user.Password, login.Contraseña);


                //if it is a valid user


                if (validation)
                {
                    var token = new Token();

                    token.JWTToken = GenerateToken(user);
                    token.Usuario = _mapper.Map<UsuarioDto>(user);


                    return Ok(token);
                }
                else
                {
                    return Unauthorized(new { message = "La contraseña proporcionada es incorrecta" });
                }
            }
            catch (Exception err)
            {


                if (err.InnerException != null)
                {

                    return BadRequest(new { message = new { message = $"Error: {err.Message}\n Inner Error: {err.InnerException.Message}" } });


                }
                else
                {
                    return BadRequest(new { message = $"Error: {err.Message} " });


                }

            }


        }



        private string GenerateToken(Usuario user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {

                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Role,Enum.GetName(typeof(RoleType),user.Role)),
                new Claim("expire", DateTime.Now.AddDays(1).ToString())

            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddDays(1)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


    public class Token
    {
        public string JWTToken { get; set; }

        public UsuarioDto Usuario { get; set; }
    }
}