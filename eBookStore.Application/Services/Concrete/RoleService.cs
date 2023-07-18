using AutoMapper;
using eBookStore.Application.DTOs.Role;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Application.Services.Concrete;

public class RoleService : IRoleService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public RoleService(
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;
    }

    public async Task<bool> CreateRoleAsync(RoleDTO roleDTO)
    {
        var role = _mapper.Map<Role>(roleDTO);

        var result = await _roleManager.CreateAsync(role);

        return result.Succeeded;
    }

    public async Task<bool> DeleteRoleAsync(int roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        if (role == null)
        {
            return false; // Role not found
        }

        var result = await _roleManager.DeleteAsync(role);

        return result.Succeeded;
    }

    public async Task<List<RoleDTO>> GetAllRolesAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        var roleDTOs = _mapper.Map<List<RoleDTO>>(roles);
        return roleDTOs;
    }

    public async Task<RoleDTO> GetRoleAsync(int roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        if (role == null)
        {
            return null; // Role not found
        }

        var roleDTO = _mapper.Map<RoleDTO>(role);
        return roleDTO;
    }

    public async Task<bool> AddRoleToUserAsync(UserRoleDTO userRoleDTO)
    {
        var user = await _userManager.FindByIdAsync(userRoleDTO.UserId.ToString());

        if (user == null)
        {
            return false; // User not found
        }

        var rolesToAdd = await _roleManager.Roles.Where(r => userRoleDTO.RoleIds.Contains(r.Id)).ToListAsync();

        foreach (var role in rolesToAdd)
        {
            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                return false; // Failed to add role to user
            }
        }

        return true; // Successfully added roles to user
    }

    public async Task<bool> RemoveRoleFromUserAsync(UserRoleDTO userRoleDTO)
    {
        var user = await _userManager.FindByIdAsync(userRoleDTO.UserId.ToString());

        if (user == null)
        {
            return false; // User not found
        }

        var rolesToRemove = await _roleManager.Roles.Where(r => userRoleDTO.RoleIds.Contains(r.Id)).ToListAsync();

        foreach (var role in rolesToRemove)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                return false; // Failed to remove role from user
            }
        }

        return true; // Successfully removed roles from user
    }

    public async Task<bool> RoleExistsAsync(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        return role != null;
    }   
}


