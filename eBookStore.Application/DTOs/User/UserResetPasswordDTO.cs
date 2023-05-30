namespace eBookStore.Application.DTOs.User;

public class UserResetPasswordDTO
{
    public int UserId { get; set; }
    public string NewPassword { get; set; }
}