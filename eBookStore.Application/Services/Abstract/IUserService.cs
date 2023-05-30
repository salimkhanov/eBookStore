using eBookStore.Application.DTOs.User;
using IdentityTask.DTOs.User;


namespace IdentityTask.Services.Abstract;

public interface IUserService
{
    Task<bool> AddRoleToUserAsync(int UserId, int RoleId);
    Task<bool> AddRolesToUserAsync(int UserId, List<int> RoleIds);
    Task<bool> RemoveUserRoleAsync(int UserId, int RoleId);
    Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    Task<bool> ResetPassword(UserResetPasswordDTO userChangePasswordDTO);
    Task<bool> DeactivateUser(int UserId);
    Task<bool> ActivateUser(int UserId);
    Task<bool> UpdateUserRoles(int UserId, List<int> RoleIds);
    Task<bool> EditUser(UserUpdateDTO userEdit);
}
