namespace IdentityTask.Services.Abstract;

public interface IRoleService
{
    Task<bool> AddRoleAsync(string roleName);
    List<string> GetRoles();
    Task<bool> DeactivateRole(int RoleId);
}
