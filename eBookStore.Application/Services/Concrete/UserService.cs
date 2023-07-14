using AutoMapper;
using eBookStore.Application.AutoMapper;
using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Concrete;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserService(
        UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<UserResponseDTO>> GetUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        var userDTOs = _mapper.Map<List<UserResponseDTO>>(users);
        return userDTOs;
    }

    public async Task<UserResponseDTO> GetUser(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null)
        {
            return null; // User not found
        }

        var userDTO = _mapper.Map<UserResponseDTO>(user);
        return userDTO;
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

    public async Task<bool> ChangePassword(ChangePasswordDTO changePasswordDTO)
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

    public async Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
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

    public async Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO)
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

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user == null)
        {
            return false; // User not found
        }

        var result = await _userManager.DeleteAsync(user);

        return result.Succeeded;
    }

    public async Task<bool> UserExists(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user != null;
    }
}
