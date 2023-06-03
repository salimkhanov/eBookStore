using AutoMapper;
using eBookStore.Application.DTOs.RoleDTO;
using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities.Authorizations;
using eBookStore.Domain.Enums;
using IdentityTask.DTOs.User;
using IdentityTask.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace eBookStore.Application.Services.Concrete;
public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;


    public UserService(
        UserManager<User> userManager,IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<string> Registration(RegistrationDTO registrationDTO)
    {
        var user = _mapper.Map<User>(registrationDTO);

        var result = await _userManager.CreateAsync(user, registrationDTO.Password);

        if (result.Succeeded)
        {
            return "User registration successful.";
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return "User registration failed. Errors: " + string.Join(", ", errors);
        }
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

    public List<UsersDropDownDTO> AllUsersForDropDown()
    {
        List<UsersDropDownDTO> users = null;

        users = _userManager.Users.Where(x => x.EntityStatus == EntityStatus.Active)
            .OrderBy(u => u.UserName)
            .Select(x => new UsersDropDownDTO() { Key = x.Id, Value = x.UserName }).ToList();
        return users;
    }
}
