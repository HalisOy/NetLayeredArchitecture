using Business.Abstracts;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn([FromBody] UserForLoginDto userForLoginDto)
        {
            return Ok(_authService.SignIn(userForLoginDto));
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            return Ok(_authService.Register(userForRegisterDto));
        }

    }
}
