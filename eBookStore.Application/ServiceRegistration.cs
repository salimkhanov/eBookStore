using eBookStore.Application.Services.Concrete;
using IdentityTask.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace eBookStore.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayerService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
/*
 
 add DI with Scan 
 
 */
}