using eBookStore.Application.DTOs.User;
using eBookStore.Domain.Entities;

namespace eBookStore.Application.Services.Abstract;

public interface IUserService
{
    Task<List<UserResponseDTO>> GetUsersAsync();
    Task<UserResponseDTO> GetUserByIdAsync(int id);
    Task<bool> DeactivateUserAsync(int UserId);
    Task<bool> ActivateUserAsync(int UserId);
    Task<string> RegistrationAsync(RegistrationDTO registrationDTO);
    Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    Task<bool> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    Task<bool> DeleteUserAsync(int id);
    Task<bool> UpdateUserAsync(UserUpdateDTO userUpdateDTO);
    Task<bool> UserExistsAsync(string email);
    Task<User> GetCurrentUserAsync();
    Task<int> GetCurrentUserIdAsync();
}
