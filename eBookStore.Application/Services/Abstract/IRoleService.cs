using eBookStore.Application.DTOs.Role;

namespace eBookStore.Application.Services.Abstract;

public interface IRoleService
{
    Task<bool> CreateRole(RoleDTO roleDTO);
    Task<bool> DeleteRole(int roleId);
    Task<List<RoleDTO>> GetAllRoles();
    Task<RoleDTO> GetRole(int roleId);
    Task<bool> AddRoleToUserAsync(UserRoleDTO userRoleDTO);
    Task<bool> RemoveRoleFromUserAsync(UserRoleDTO userRoleDTO);
    Task<bool> RoleExists(string roleName);
}
