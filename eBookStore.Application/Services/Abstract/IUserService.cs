using eBookStore.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Abstract;

public interface IUserService
{
    Task<List<UserResponseDTO>> GetUsers();
    Task<UserResponseDTO> GetUser(int id);
    Task<bool> DeactivateUser(int UserId);
    Task<bool> ActivateUser(int UserId);
    Task<string> Registration(RegistrationDTO registrationDTO);
    Task<bool> ChangePassword(ChangePasswordDTO changePasswordDTO);
    Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO);
    Task<bool> DeleteUser(int id);
    Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO);
    Task<bool> UserExists(string email);
}
