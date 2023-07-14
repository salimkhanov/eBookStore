namespace eBookStore.Application.DTOs.User;

public class ResetPasswordDTO
{
    public int UserId { get; set; }
    public string NewPassword { get; set; }
}
