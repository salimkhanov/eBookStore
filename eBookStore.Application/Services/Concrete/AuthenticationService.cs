using eBookStore.Application.DTOs.Authentication;
using eBookStore.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookStore.Application.Services.Concrete;

public class AuthenticationService : IAuthenticationService
{

    public Task<string> Login(LoginDto login)
    {
        throw new NotImplementedException();
    }
}
