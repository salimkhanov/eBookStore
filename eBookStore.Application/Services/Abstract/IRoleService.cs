using eBookStore.Application.DTOs.Role;

namespace eBookStore.Application.Services.Abstract;

public interface IRoleService
{
    Task<bool> CreateRoleAsync(RoleDTO roleDTO);
    Task<bool> DeleteRoleAsync(int roleId);
    Task<List<RoleDTO>> GetAllRolesAsync();
    Task<RoleDTO> GetRoleAsync(int roleId);
    Task<bool> AddRoleToUserAsync(UserRoleDTO userRoleDTO);
    Task<bool> RemoveRoleFromUserAsync(UserRoleDTO userRoleDTO);
    Task<bool> RoleExistsAsync(string roleName);
}
