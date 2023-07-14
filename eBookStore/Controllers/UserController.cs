using eBookStore.Application.DTOs.Authentication;
using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("User")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService; 

    public UserController(
        IAuthService authService,
        IUserService userService)
    {
        _authService = authService;
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromQuery] LoginDTO loginDTO)
    {
        var tokenResponse = await _authService.Login(loginDTO);
        if (tokenResponse != null)
        {
            return Ok(tokenResponse);
        }
        return NotFound("User not found");
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _userService.GetUsers());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _userService.GetUser(id);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest($"User with ID {id} not found");
    }

    [HttpPost("Registration")]
    public async Task<IActionResult> Registration(RegistrationDTO registrationDTO)
    {
        if (await _userService.UserExists(registrationDTO.Email))
        {
            return BadRequest("User already exist");
        }

        return Ok(await _userService.Registration(registrationDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        if (await _userService.UpdateUser(userUpdateDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        if (await _userService.DeleteUser(userId))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

}
