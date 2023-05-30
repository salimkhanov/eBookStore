using eBookStore.Application.Services.Concrete;
using eBookStore.Domain.Entities;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Route("/AddRole")]
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            var result = await _roleService.CreateRole(roleName);
            if (result)
            {
                return Ok("Role added successfully");
            }
            else
            {
                return BadRequest("Failed to add role");
            }
        }

        
        [Route("GetRoles")]
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(_roleService.GetRoles());
        }

        [Route("/DeactivateRole")]
        [HttpPut]
        public async Task<IActionResult> DeactivateRole(int RoleId)
        {
            var result = await _roleService.DeactivateRole(RoleId);
            if (true)
            {
                return Ok("Successful to deactivate role");
            }
            else
            {
                return BadRequest("Failed to deactivate role");
            }
        }
    }

}
