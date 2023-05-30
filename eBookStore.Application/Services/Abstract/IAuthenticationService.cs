using eBookStore.Domain.Entities;
using IdentityTask.DTOs.Authentication;

namespace IdentityTask.Services.Abstract;

public interface IAuthenticationService
{
    Task<string> Login(LoginDTO login);
    Task<string> Registration(RegistrationDTO registration);
}