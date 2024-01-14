using eBookStore.Application.DTOs.Authentication;
using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("User")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
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
        return Ok(await _userService.GetUsersAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"User with ID {id} not found");
    }

    [HttpPost("Registration")]
    [AllowAnonymous]
    public async Task<IActionResult> Registration(RegistrationDTO registrationDTO)
    {
        if (await _userService.UserExistsAsync(registrationDTO.Email))
        {
            return BadRequest("User already exist");
        }

        return Ok(await _userService.RegistrationAsync(registrationDTO));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        if (await _userService.UpdateUserAsync(userUpdateDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        if (await _userService.DeleteUserAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [Authorize(Roles = "User, Admin")]
    [HttpPut("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
    {
        if (await _userService.ChangePasswordAsync(changePasswordDTO))
        {
            return Ok("Password changed successfully");
        }
        return NotFound();
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("ResetPassword")]
    public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
    {
        if (await _userService.ResetPasswordAsync(resetPasswordDTO))
        {
            return Ok("Password reset successfully");
        }
        return NotFound();
    }
}
