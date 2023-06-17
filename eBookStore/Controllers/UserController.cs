using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using eBookStore.Domain.Entities;
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
            if (await _userService.DeactivateUser(UserId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"User with ID {UserId} not found.");
        }

        [Route("/ActivateUser")]
        [HttpPut]
        public async Task<IActionResult> ActivateUser(int UserId)
        {
            if (await _userService.ActivateUser(UserId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"User with ID {UserId} not found.");
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

        [Route("/GetAllUsers")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [Route("/GetUserById")]
        [HttpGet]
        public IActionResult GetUserById(int userId)
        {
            var result = _userService.GetUsersById(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest($"User with ID {userId} not found");
        }

        [Route("/DeleteUser")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userService.DeleteUser(userId);
            if (result)
            {
                return Ok("Successful to delete user");
            }
            else
            {
                return BadRequest($"User with ID {userId} not found");
            }
        }
    }
}
