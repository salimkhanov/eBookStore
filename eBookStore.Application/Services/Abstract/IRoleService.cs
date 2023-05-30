using eBookStore.Application.DTOs.Roles;

namespace IdentityTask.Services.Abstract;

public interface IRoleService
{
    Task<bool> CreateRole(string roleName);
    List<string> GetRoles(); // crea dto for this method (at next lesson)
    List<RoleDropDownDTO> AllRolesForDropDown();
    Task<bool> DeactivateRole(int RoleId);
}