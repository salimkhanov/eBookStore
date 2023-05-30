using System.ComponentModel.DataAnnotations;

namespace IdentityTask.DTOs.Authentication;

public class LoginDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
