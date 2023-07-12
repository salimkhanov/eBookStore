using eBookStore.Application.DTOs.Role.Request;
using eBookStore.Application.DTOs.Role.Response;
using eBookStore.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Concrete;

public class RoleService : IRoleService
{
    public Task<bool> AddRoleToUserAsync(UserRoleDto userRoleDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateRoleAsync(RoleCreateDto roleCreateDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteRole(int roleId)
    {
        throw new NotImplementedException();
    }

    public List<RoleResponseDto> GetAllRoles()
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveUserFromRoleAsync(UserRoleDto userRoleDTO)
    {
        throw new NotImplementedException();
    }
}
