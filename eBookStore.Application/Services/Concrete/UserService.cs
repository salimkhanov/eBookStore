using AutoMapper;
using eBookStore.Application.DTOs.Role;
using eBookStore.Application.DTOs.RoleDTO;
using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities;
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

    public List<GetAllUsersDTO> GetAllUsers()
    {
        List<GetAllUsersDTO> users = null;

        users = _userManager.Users
            .OrderBy(u => u.Id)
            .Select(x => new GetAllUsersDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EntityStatus = x.EntityStatus,
                UserName = x.UserName,
                NormalizedUserName = x.NormalizedUserName,
                Email = x.Email,
                NormalizedEmail = x.NormalizedEmail,
                EmailConfirmed = x.EmailConfirmed,
                PasswordHash = x.PasswordHash,
                SecurityStamp = x.SecurityStamp,
                ConcurrencyStamp = x.ConcurrencyStamp,
                PhoneNumber = x.PhoneNumber,
                PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                TwoFactorEnabled = x.TwoFactorEnabled,
                LockoutEnd = x.LockoutEnd,
                LockoutEnabled = x.LockoutEnabled,
                AccessFailed = x.AccessFailedCount
            }).ToList();
        return users;
    }

    public GetAllUsersDTO GetUsersById(int userId)
    {
        GetAllUsersDTO users = null;

        User domain = _userManager.Users.FirstOrDefault(u => u.Id == userId);

        if (domain != null)
        {
            users = new GetAllUsersDTO()
            {
                Id = domain.Id,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                EntityStatus = domain.EntityStatus,
                UserName = domain.UserName,
                NormalizedUserName = domain.NormalizedUserName,
                Email = domain.Email,
                NormalizedEmail = domain.NormalizedEmail,
                EmailConfirmed = domain.EmailConfirmed,
                PasswordHash = domain.PasswordHash,
                SecurityStamp = domain.SecurityStamp,
                ConcurrencyStamp = domain.ConcurrencyStamp,
                PhoneNumber = domain.PhoneNumber,
                PhoneNumberConfirmed = domain.PhoneNumberConfirmed,
                TwoFactorEnabled = domain.TwoFactorEnabled,
                LockoutEnd = domain.LockoutEnd,
                LockoutEnabled = domain.LockoutEnabled,
                AccessFailed = domain.AccessFailedCount
            };
            return users;
        }
        return null;
    }

    public async Task<bool> DeleteUser(int userId)
    {
        User user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

        if (user != null)
        {
            _userManager.DeleteAsync(user);
            return true;
        }
        return false;
    }
}
