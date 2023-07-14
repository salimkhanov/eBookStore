using eBookStore.Application.DTOs.Role;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Role")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(await _roleService.GetAllRoles());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRole(int id)
    {
        var result = await _roleService.GetRole(id);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest($"Role with ID {id} not found");
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateRole(RoleDTO roleDTO)
    {
        if (await _roleService.RoleExists(roleDTO.Id.ToString()))
        {
            return BadRequest("Role already exist");
        }
        if(!await _roleService.CreateRole(roleDTO))
        {
            return BadRequest("Something went wrong");
        }
        return Ok("Role successful created");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        if (await _roleService.DeleteRole(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPut("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUser(UserRoleDTO userRoleDTO)
    {
        if(!await _roleService.AddRoleToUserAsync(userRoleDTO))
        {
            return BadRequest();
        }
        return Ok("Roles added to user");
    }

    [HttpPut("RemoveRoleFromUser")]
    public async Task<IActionResult> RemoveRoleFromUser(UserRoleDTO userRoleDTO)
    {
        if (!await _roleService.AddRoleToUserAsync(userRoleDTO))
        {
            return BadRequest();
        }
        return Ok("Roles removed from user");
    }
}
