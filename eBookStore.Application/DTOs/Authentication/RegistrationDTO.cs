using System.ComponentModel.DataAnnotations;

namespace IdentityTask.DTOs.Authentication;

public class RegistrationDTO
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}

