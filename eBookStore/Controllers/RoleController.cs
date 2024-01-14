using eBookStore.Application.DTOs.Role;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Role")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllRolesAsync()
    {
        return Ok(await _roleService.GetAllRolesAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRoleAsync(int id)
    {
        var result = await _roleService.GetRoleAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return BadRequest($"Role with ID {id} not found");
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateRoleAsync(RoleDTO roleDTO)
    {
        if (await _roleService.RoleExistsAsync(roleDTO.Id.ToString()))
        {
            return BadRequest("Role already exist");
        }
        if(!await _roleService.CreateRoleAsync(roleDTO))
        {
            return BadRequest("Something went wrong");
        }
        return Ok("Role successful created");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRoleAsync(int id)
    {
        if (await _roleService.DeleteRoleAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPut("AddRoleToUser")]
    public async Task<IActionResult> AddRoleToUserAsync(UserRoleDTO userRoleDTO)
    {
        if(!await _roleService.AddRoleToUserAsync(userRoleDTO))
        {
            return BadRequest();
        }
        return Ok("Roles added to user");
    }

    [HttpPut("RemoveRoleFromUser")] 
    public async Task<IActionResult> RemoveRoleFromUserAsync(UserRoleDTO userRoleDTO)
    {
        if (!await _roleService.RemoveRoleFromUserAsync(userRoleDTO))
        {
            return BadRequest();
        }
        return Ok("Roles removed from user");
    }
}
