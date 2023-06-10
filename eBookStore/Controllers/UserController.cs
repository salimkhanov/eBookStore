using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Concrete;
using IdentityTask.DTOs.User;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [Route("/Registration")]
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationDTO registrationDTO)
        {
            var message = await _userService.Registration(registrationDTO);
            return Ok(message);
        }

        [Route("/ChangePassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var result = await _userService.ChangePasswordAsync(changePasswordDTO);
            if (result)
            {
                return Ok("Password changed successfully");
            }
            else
            {
                return BadRequest("Failed to change password");
            }
        }

        [Authorize(Roles = "HR")]
        [Route("/ResetPassword")]
        [HttpPut]
        public async Task<IActionResult> ResetPassword(UserResetPasswordDTO userResetPasswordDTO)
        {
            var result = await _userService.ResetPassword(userResetPasswordDTO);
            if (result)
            {
                return Ok("Password reset successfully");
            }
            else
            {
                return BadRequest("Failed to reset password");
            }
        }

        [Route("/DeactivateUser")]
        [HttpPut]
        public async Task<IActionResult> DeactivateUser(int UserId)
        {
            var result = await _userService.DeactivateUser(UserId);
            if (true)
            {
                return Ok("Successful to deactivate user");
            }
            else
            {
                return BadRequest("Failed to deactivate user");
            }
        }

        [Route("/ActivateUser")]
        [HttpPut]
        public async Task<IActionResult> ActivateUser(int UserId)
        {
            var result = await _userService.ActivateUser(UserId);
            if (true)
            {
                return Ok("Successful to activate user");
            }
            else
            {
                return BadRequest("Failed to activate user");
            }
        }

        [Route("/EditUser")]
        [HttpPut]
        public async Task<IActionResult> EditUser(UserUpdateDTO userUpdateDTO)
        {
            var result = await _userService.EditUser(userUpdateDTO);
            if (true)
            {
                return Ok("Successful to update user");
            }
            else
            {
                return BadRequest("Failed to update user");
            }
        }

        [Route("/AllUsersForDropDown")]
        [HttpGet]
        public IActionResult AllUsersForDropDown()
        {
            return Ok(_userService.AllUsersForDropDown());
        }
    }
}
