using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.DTOs.User.Request;

public class ChangePasswordDTO
{
    public string Email { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}
