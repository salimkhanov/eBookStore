using AutoMapper;
using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace eBookStore.Application.Services.Concrete;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(
        UserManager<User> userManager, 
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<UserResponseDTO>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var userDTOs = _mapper.Map<List<UserResponseDTO>>(users);
        return userDTOs;
    }

    public async Task<UserResponseDTO> GetUserByIdAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null)
        {
            return null; // User not found
        }

        var userDTO = _mapper.Map<UserResponseDTO>(user);
        return userDTO;
    }

    public async Task<string> RegistrationAsync(RegistrationDTO registrationDTO)
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
            return false; // User not found
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, changePasswordDTO.CurrentPassword);
        if (!isPasswordValid)
        {
            return false; // Current password is incorrect
        }

        var result = await _userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);

        return result.Succeeded;
    }

    public async Task<bool> DeactivateUserAsync(int UserId)
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

    public async Task<bool> ActivateUserAsync(int UserId)
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

    public async Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
    {
        User user = _userManager.Users.SingleOrDefault(u => u.Id == resetPasswordDTO.UserId && u.EntityStatus == EntityStatus.Active);
        if (user == null)
        {
            return false;
        }
        string passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, passResetToken, resetPasswordDTO.NewPassword);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> UpdateUserAsync(UserUpdateDTO userUpdateDTO)
    {
        var user = await _userManager.FindByIdAsync(userUpdateDTO.Id.ToString());

        if (user == null)
        {
            return false; // User not found
        }

        _mapper.Map<User>(userUpdateDTO);

        var result = await _userManager.UpdateAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null)
        {
            return false; // User not found
        }

        var result = await _userManager.DeleteAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> UserExistsAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user != null;
    }

    public async Task<User> GetCurrentUserAsync()   
    {
        string currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(currentUserId))
        {
            return null;
        }

        var user = await _userManager.FindByIdAsync(currentUserId);
        return user;
    }

    public async Task<int> GetCurrentUserIdAsync()
    {
        string currentUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(currentUserId))
        {
            return 0;
        }
        return Convert.ToInt32(currentUserId);
    }
}
