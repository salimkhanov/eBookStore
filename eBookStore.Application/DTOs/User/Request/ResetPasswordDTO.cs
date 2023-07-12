namespace eBookStore.Application.DTOs.User.Request;

public class ResetPasswordDTO
{
    public int UserId { get; set; }
    public string NewPassword { get; set; }
}
