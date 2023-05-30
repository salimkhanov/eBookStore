using eBookStore.Domain.Entities;
using IdentityTask.DTOs.Authentication;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }


        [Route("Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO userLogin)
        {
            var token = await _authService.Login(userLogin);
            if (token != null)
            {
                return Ok(token);
            }
            return NotFound("User not found");

        }

        [Route("Registration")]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationDTO registrationDTO)
        {
            var message = await _authService.Registration(registrationDTO);
            return Ok(message);
        }
    }
}