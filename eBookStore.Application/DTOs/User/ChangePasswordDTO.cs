namespace eBookStore.Application.DTOs.User;

public class ChangePasswordDTO
{
    public string Email { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
