using System.ComponentModel.DataAnnotations;

namespace IdentityTask.DTOs.User;

public class ChangePasswordDTO
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string CurrentPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }
}
