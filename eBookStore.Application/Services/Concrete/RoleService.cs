using eBookStore.Application.DTOs.Roles;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Concrete;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    public RoleService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> CreateRole(string roleName) // DTO NAME and OrderIndex
    {
        bool isRoleExist = await _roleManager.RoleExistsAsync(roleName);
        if (isRoleExist)
        {
            return false;
        }
        var role = new Role { Name = roleName };
        var result = await _roleManager.CreateAsync(role);
        return result.Succeeded;
    }
    public async Task<bool> DeactivateRole(int RoleId)
    {
        Role? role = await _roleManager.Roles.
            SingleOrDefaultAsync(u => u.Id == RoleId && u.EntityStatus == EntityStatus.Active);
        if (role is null)
        {
            return false;
        }
        role.EntityStatus = EntityStatus.Deactive;
        var result = await _roleManager.UpdateAsync(role);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }
    public List<string> GetRoles()
    {
        var roles = _roleManager.Roles.Where(x => x.EntityStatus == EntityStatus.Active).
            Select(r => r.Name).ToList();

        if (roles is null || roles.Count == 0)
        {
            roles.Add("Role does not exist");
        }
        return roles;
    }
    public List<RoleDropDownDTO> AllRolesForDropDown()
    {
        List<RoleDropDownDTO> roles = _roleManager.Roles.
            Where(x => x.EntityStatus == EntityStatus.Active).
            OrderBy(u => u.OrderIndex).
            Select(x => new RoleDropDownDTO() { Key = x.Id, Value = x.Name }).ToList();
        return roles;
    }
}