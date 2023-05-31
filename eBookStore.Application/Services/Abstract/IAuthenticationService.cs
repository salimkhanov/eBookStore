using eBookStore.Domain.Entities;
using IdentityTask.DTOs.Authentication;

namespace IdentityTask.Services.Abstract;

public interface IAuthenticationService
{
    Task<string> Login(LoginDTO login);
    Task<string> GenerateTokenAsync(User user,List<string> roles);
    Task<string> Registration(RegistrationDTO registration);
}
