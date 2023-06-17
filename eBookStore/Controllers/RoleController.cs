using eBookStore.Application.DTOs.Role;
using eBookStore.Application.Services.Concrete;
using eBookStore.Domain.Entities;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Route("/CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDTO createRoleDTO)
        {
            var result = await _roleService.CreateRoleAsync(createRoleDTO);
            if (result)
            {
                return Ok("Role added successfully");
            }
            else
            {
                return BadRequest("Failed to add role");
            }
        }

        [Route("/UpdateUserRole")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserRole(int UserId, List<int> RoleIds)
        {
            var result = await _roleService.UpdateUserRoles(UserId, RoleIds);
            if (true)
            {
                return Ok("Successful to update user");
            }
            else
            {
                return BadRequest("Failed to update user");
            }
        }

        [Route("/AddRoleToUser")]
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(int UserId, int RoleId)
        {
            var result = await _roleService.AddRoleToUserAsync(UserId, RoleId);
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
        public async Task<IActionResult> AddRolesToUser(int user, List<int> roles)
        {
            var result = await _roleService.AddRolesToUserAsync(user, roles);
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
        public async Task<IActionResult> RemoveUserRole(int UserId, int RoleId)
        {
            var result = await _roleService.RemoveUserFromRoleAsync(UserId, RoleId);
            if (result)
            {
                return Ok("Role removed from user successfully");
            }
            else
            {
                return BadRequest("Failed to remove role from user");
            }
        }


        [Route("/GetAllRoles")]
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleService.GetAllRoles());
        }

        [Route("/GetUsersRoles")]
        [HttpGet]
        public async Task<IActionResult> GetUsersRoles(int UserId)
        {
            return Ok(await _roleService.UserRoles(UserId));
            
        }

        [Route("/AllRolesForDropDown")]
        [HttpGet]
        public IActionResult AllRolesForDropDown()
        {
            return Ok(_roleService.AllRolesForDropDown());
        }

        [Route("/DeactivateRole")]
        [HttpPut]
        public async Task<IActionResult> DeactivateRole(int RoleId)
        {
            if (await _roleService.DeactivateRole(RoleId))
            {
                return Ok("Successfully deactivated");
            }
            return BadRequest($"Role with ID {RoleId} not found.");
        }

        [Route("/DeleteRole")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(int RoleId)
        {
            var result = await _roleService.DeleteRole(RoleId);
            if (result)
            {
                return Ok("Successful to delete role");
            }
            else
            {
                return BadRequest($"Role with ID {RoleId} not found");
            }
        }

        [Route("/ActivateRole")]
        [HttpPut]
        public async Task<IActionResult> ActivateRole(int RoleId)
        {
            if (await _roleService.ActivateRole(RoleId))
            {
                return Ok("Successfully activated");
            }
            return BadRequest($"Role with ID {RoleId} not found.");
        }

        [Route("/GetRoleById")]
        [HttpGet]
        public IActionResult GetRoleById(int roleId)
        {
            var result = _roleService.GetRoleById(roleId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest($"Role with ID {roleId} not found");
        }
    }
}
