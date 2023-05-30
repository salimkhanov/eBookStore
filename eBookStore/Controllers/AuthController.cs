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
    //[Authorize(Roles = "hr")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [Route("/Login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromQuery] LoginDTO userLogin)
        {
            var token = await _authService.Login(userLogin);
            if (token != null)
            {
                return Ok(token);
            }
            return NotFound("User not found");

        }

        [Route("/Registration")]
        [HttpPost]

        public async Task<IActionResult> Registration(RegistrationDTO registrationDTO)
        {
            var message = await _authService.Registration(registrationDTO);
            return Ok(message);
        }
    }
}
