using eBookStore.Application.DTOs.Role.Request;
using eBookStore.Application.DTOs.Role.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Abstract;

public interface IRoleService
{
    Task<bool> CreateRoleAsync(RoleCreateDTO roleCreateDTO);
    List<RoleResponseDTO> GetAllRoles();
    Task<bool> DeleteRole(int roleId);
    Task<bool> AddRoleToUserAsync(UserRoleDTO userRoleDTO);
    Task<bool> RemoveUserFromRoleAsync(UserRoleDTO userRoleDTO);
}
