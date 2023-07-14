namespace eBookStore.Application.DTOs.Role;

public record UserRoleDTO(
    int UserId,
    int[] RoleIds); 
