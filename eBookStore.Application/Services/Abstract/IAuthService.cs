using eBookStore.Application.DTOs.Authentication;

namespace eBookStore.Application.Services.Abstract;

public interface IAuthService
{   
    Task<string> Login(LoginDTO login);
}
