using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using IdentityTask.DTOs.User;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Application.Services.Concrete;
public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public UserService(
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> AddRoleToUserAsync(int UserId,int RoleId)
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
    public async Task<bool> RemoveUserRoleAsync(int UserId,int RoleId)
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
    public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
    {
        var user = await _userManager.FindByEmailAsync(changePasswordDTO.Email);
        if (user == null)
        {
            return false;
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, changePasswordDTO.CurrentPassword);
        if (!isPasswordValid)
        {
            return false;
        }

        var result = await _userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);

        return result.Succeeded;
    }
    public async Task<bool> ResetPassword(UserResetPasswordDTO userChangePasswordDTO)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == userChangePasswordDTO.UserId && u.EntityStatus == EntityStatus.Active);
        if (user == null)
        {
            return false;
        }
        string passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, passResetToken, userChangePasswordDTO.NewPassword);
        if (!result.Succeeded)
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
    public async Task<bool> DeactivateUser(int UserId)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == UserId && u.EntityStatus == EntityStatus.Active);
        if (user == null)
        {
           return false;
        }
        user.EntityStatus = EntityStatus.Deactive;
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> ActivateUser(int UserId)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == UserId && u.EntityStatus == EntityStatus.Deactive);
        if (user == null)
        {
            return false;
        }
        user.EntityStatus = EntityStatus.Active;
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
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

    public async Task<bool> EditUser(UserUpdateDTO userEdit)
    {
        User IdentityUser = _userManager.Users.SingleOrDefault(u => u.Id == userEdit.Id && u.EntityStatus == EntityStatus.Active);
        if (IdentityUser is null)
        {
            return false;
        }
        IdentityUser.UserName = userEdit.UserName;
        IdentityUser.FirstName = userEdit.FirstName;
        IdentityUser.LastName = userEdit.LastName;
        IdentityUser.Email = userEdit.Email;
        var result = await _userManager.UpdateAsync(IdentityUser);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }
}
