using eBookStore.Application.DTOs.Authentication;

namespace eBookStore.Application.Services.Abstract;

public interface IAuthenticationService
{
    Task<string> Login(LoginDTO login);
}
