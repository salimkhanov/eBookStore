using eBookStore.Application.DTOs.User.Request;
using eBookStore.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Concrete;

public class UserService : IUserService
{
    public UserService()
    {
        
    }
    public Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
    {
        throw new NotImplementedException();
    }

    public Task<string> Registration(RegistrationDTO registrationDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ResetPassword(ResetPasswordDTO resetPasswordDTO)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateUser(UserUpdateDTO userUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
