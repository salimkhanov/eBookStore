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
    Task<bool> CreateRoleAsync(RoleCreateDto roleCreateDTO);
    List<RoleResponseDto> GetAllRoles();
    Task<bool> DeleteRole(int roleId);
    Task<bool> AddRoleToUserAsync(UserRoleDto userRoleDTO);
    Task<bool> RemoveUserFromRoleAsync(UserRoleDto userRoleDTO);
}
