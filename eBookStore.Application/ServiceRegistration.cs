using eBookStore.Application.ApplicationAssemblyMarker;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Persistence.Repositories.EntityRepositories;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eBookStore.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationLayerService(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();

            services.Scan(scan => scan.FromAssemblies(typeof(IApplicationAssemblyMarker).Assembly)
            .AddClasses(@class => @class.Where(type => !type.Name.StartsWith('I')
            && type.Name.EndsWith("Service")))
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        }
    }
}
