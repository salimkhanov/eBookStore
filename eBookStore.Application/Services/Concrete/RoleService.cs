using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Identity;
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

    public async Task<bool> AddRoleAsync(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return false;
        }

        var role = new Role { Name = roleName };
        var result = await _roleManager.CreateAsync(role);

        return result.Succeeded;
    }
    public async Task<bool> DeactivateRole(int RoleId)
    {
        Role role = _roleManager.Roles.SingleOrDefault(u => u.Id == RoleId && u.EntityStatus == EntityStatus.Active);
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
        var roles = new List<string>();

        roles = _roleManager.Roles.Where(x => x.EntityStatus== EntityStatus.Active).Select(r => r.Name).ToList();

        if (roles is null || roles.Count == 0)
        {
            roles.Add("Role does not exist");
        }
        return roles;
    }
}
