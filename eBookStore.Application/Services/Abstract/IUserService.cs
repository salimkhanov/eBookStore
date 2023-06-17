using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.Role;
using eBookStore.Application.DTOs.RoleDTO;
using eBookStore.Application.DTOs.User;
using IdentityTask.DTOs.User;


namespace IdentityTask.Services.Abstract;

public interface IUserService
{
    Task<string> Registration(RegistrationDTO registration);
    Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    Task<bool> ResetPassword(UserResetPasswordDTO userChangePasswordDTO);
    Task<bool> DeactivateUser(int UserId);
    Task<bool> ActivateUser(int UserId);
    Task<bool> EditUser(UserUpdateDTO userEdit);
    List<UsersDropDownDTO> AllUsersForDropDown();
    List<GetAllUsersDTO> GetAllUsers();
    GetAllUsersDTO GetUsersById(int userId);
    Task<bool> DeleteUser(int userId);
}
