using eBookStore.Application.DTOs.Role;
using eBookStore.Application.DTOs.RoleDTO;

namespace IdentityTask.Services.Abstract;

public interface IRoleService
{
    Task<bool> CreateRoleAsync(CreateRoleDTO createRoleDTO);
    List<GetAllRoleDTO> GetAllRoles();
    List<RoleDropDownDTO> AllRolesForDropDown();
    Task<IList<UserRolesViewDTO>> UserRoles(int UserId);
    Task<bool> DeactivateRole(int RoleId);
    Task<bool> DeleteRole(int RoleId);
    Task<bool> ActivateRole(int RoleId);
    Task<bool> AddRoleToUserAsync(int UserId, int RoleId);
    Task<bool> AddRolesToUserAsync(int UserId, List<int> RoleIds);
    Task<bool> RemoveUserFromRoleAsync(int UserId, int RoleId);
    Task<bool> UpdateUserRoles(int UserId, List<int> RoleIds);
}
