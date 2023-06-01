using eBookStore.Application.DTOs.Role;
using eBookStore.Application.DTOs.RoleDTO;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Application.Services.Concrete;

public class RoleService : IRoleService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public RoleService(
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> ActivateRole(int RoleId)
    {
        Role? role = await _roleManager.Roles.SingleOrDefaultAsync(u => u.Id == RoleId && u.EntityStatus == EntityStatus.Deactive);
        if (role is null)
        {
            return false;
        }
        role.EntityStatus = EntityStatus.Active;
        var result = await _roleManager.UpdateAsync(role);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> AddRoleToUserAsync(int UserId, int RoleId)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == UserId && u.EntityStatus == EntityStatus.Active);
        Role role = _roleManager.Roles.SingleOrDefault(r => r.Id == RoleId && r.EntityStatus == EntityStatus.Active);

        if (user is null || role is null)
        {
            return false;
        }
        var result = await _userManager.AddToRoleAsync(user, role.Name);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> UpdateUserRoles(int UserId, List<int> RoleIds)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == UserId && u.EntityStatus == EntityStatus.Active);
        IList<string> userRoles = await _userManager.GetRolesAsync(user);
        if (user is null)
        {
            return false;
        }
        var result = await _userManager.RemoveFromRolesAsync(user, userRoles);
        if (result.Succeeded == false)
        {
            return false;
        }
        List<string> rolesByIds = _roleManager.Roles.Where(x => RoleIds.Contains(x.Id)).Select(n => n.Name).ToList();
        result = await _userManager.AddToRolesAsync(user, rolesByIds);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> RemoveUserFromRoleAsync(int UserId, int RoleId)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == UserId && u.EntityStatus == EntityStatus.Active);
        Role role = _roleManager.Roles.SingleOrDefault(r => r.Id == RoleId && r.EntityStatus == EntityStatus.Active);
        if (user is null || role is null)
        {
            return false;
        }
        var result = await _userManager.RemoveFromRoleAsync(user, role.Name);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> AddRolesToUserAsync(int UserId, List<int> RoleIds)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == UserId && u.EntityStatus == EntityStatus.Active);
        List<Role> rolesInApp = _roleManager.Roles.Where(x => RoleIds.Contains(x.Id)).ToList();
        if (user is null || rolesInApp is null || rolesInApp.Count == 0)
        {
            return false;
        }
        List<string> roleNames = rolesInApp.Select(n => n.Name).ToList();
        IList<string> userRoles = await _userManager.GetRolesAsync(user);
        List<string> newRolesForUser = new List<string>();
        foreach (string role in roleNames)
        {
            if (!userRoles.Contains(role))
            {
                newRolesForUser.Add(role);
            }
        }
        var result = await _userManager.AddToRolesAsync(user, newRolesForUser);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }

    public List<RoleDropDownDTO> AllRolesForDropDown()
    {
        List<RoleDropDownDTO> roles = null;

        roles = _roleManager.Roles.Where(x => x.EntityStatus == EntityStatus.Active)
            .OrderBy(u => u.OrderIndex)
            .Select(x => new RoleDropDownDTO() { Key = x.Id,Value = x.Name}).ToList();
        return roles;
    }

    public async Task<bool> CreateRoleAsync(CreateRoleDTO createRoleDTO)
    {
        bool isRoleExits = await _roleManager.RoleExistsAsync(createRoleDTO.RoleName);
        bool isOrderIndexExits = await _roleManager.Roles.AllAsync(r => r.OrderIndex != createRoleDTO.OrderIndex);

        if(isRoleExits||!isOrderIndexExits)
        {
            return false;
        }

        var role = new Role { Name = createRoleDTO.RoleName,OrderIndex = createRoleDTO.OrderIndex };
        var result = await _roleManager.CreateAsync(role);

        return result.Succeeded;
    }
    public async Task<bool> DeactivateRole(int RoleId)
    {
        Role? role = await _roleManager.Roles.SingleOrDefaultAsync(u => u.Id == RoleId && u.EntityStatus == EntityStatus.Active);
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

    public async Task<bool> DeleteRole(int RoleId)
    {
        Role? role = await _roleManager.Roles.SingleOrDefaultAsync(u => u.Id == RoleId);
        if (role is null)
        {
            return false;
        }
        var result = await _roleManager.DeleteAsync(role);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }

    public List<GetAllRoleDTO> GetAllRoles()
    {

        List<GetAllRoleDTO> roles = null;

        roles = _roleManager.Roles
            .OrderBy(u => u.OrderIndex)
            .Select(x => new GetAllRoleDTO() { Id = x.Id, EntityStatus = x.EntityStatus,Name=x.Name
            ,NormalizedName=x.NormalizedName,ConcurrencyStamp=x.ConcurrencyStamp,OrderIndex=x.OrderIndex }).ToList();
        return roles;
    }

    public async Task<IList<UserRolesViewDTO>> UserRoles(int UserId)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == UserId);
        if (user is null)
        {
            return new List<UserRolesViewDTO>();
        }
        IList<string> currentUserRoles = await _userManager.GetRolesAsync(user);
        List<UserRolesViewDTO> rolesDTO = _roleManager.Roles.Where(rl => currentUserRoles.Contains(rl.Name)).Select(value => new UserRolesViewDTO { RoleId = value.Id, UserId = UserId, RoleName = value.Name,UserName=user.UserName}).ToList();
        if (currentUserRoles.Count == 0)
        {
            return new List<UserRolesViewDTO>();
        }
        return rolesDTO;
    }
}
