using eBookStore.Application.DTOs.User;
using IdentityTask.DTOs.User;
using IdentityTask.Services.Abstract;
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


        [Route("/AddRoleToUser")]
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(int UserId,int RoleId)
        {
            var result = await _userService.AddRoleToUserAsync(UserId,RoleId);
            if (result)
            {
                return Ok("Role added to user successfully");
            }
            else
            {
                return BadRequest("Failed to add role to user");
            }
        }

        [Route("/AddRolesToUser")]
        [HttpPost]
        public async Task<IActionResult> AddRolesToUser(int user,List<int> roles)
        {
            var result = await _userService.AddRolesToUserAsync(user,roles);
            if (result)
            {
                return Ok("Role added to user successfully");
            }
            else
            {
                return BadRequest("Failed to add role to user");
            }
        }

        [Route("/RemoveUserRole")]
        [HttpDelete]
        public async Task<IActionResult> RemoveUserRole(int UserId,int RoleId)
        {
            var result = await _userService.RemoveUserFromRoleAsync(UserId,RoleId);
            if (result)
            {
                return Ok("Role removed from user successfully");
            }
            else
            {
                return BadRequest("Failed to remove role from user");
            }
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

        [Route("/UpdateUserRole")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserRole(int UserId,List<int> RoleIds)
        {
            var result = await _userService.UpdateUserRoles(UserId,RoleIds);
            if (true)
            {
                return Ok("Successful to update user");
            }
            else
            {
                return BadRequest("Failed to update user");
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

    }
}
