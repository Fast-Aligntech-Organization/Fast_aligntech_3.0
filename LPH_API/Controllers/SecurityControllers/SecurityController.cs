using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LPH.Api.Responses;
using LPH.Core.DTOs;
using LPH.Core.Entities;
using LPH.Core.Enumerations;
using LPH.Core.Interfaces; 
using System.Threading.Tasks;

namespace LPH.Api.Controllers.SecurityControllers
{
    [Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDto securityDto)
        {
            var security = _mapper.Map<User>(securityDto);

            security.Password = _passwordService.Hash(security.Password);
            await _securityService.RegisterUser(security);

            securityDto = _mapper.Map<UserDto>(security);
            var response = new ApiResponse(securityDto);
            return Ok(response);
        }

    }
}