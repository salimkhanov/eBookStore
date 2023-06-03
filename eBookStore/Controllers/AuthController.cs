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
   //[Authorize(Roles ="Admin")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        [Route("Login")]
        //[AllowAnonymous]
   
        public async Task<IActionResult> Login([FromQuery] LoginDTO userLogin)
        {
            var token = await _authService.Login(userLogin);
            if (token != null)
            {
                return Ok(token);
            }
            return NotFound("User not found");
        }
    }
}
