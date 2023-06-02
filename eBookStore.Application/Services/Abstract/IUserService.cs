using eBookStore.Application.DTOs.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Abstract;

public interface IUserService
{
    Task<string> Registration(RegistrationDTO registrationDTO);
    Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO);
    Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO);
}
