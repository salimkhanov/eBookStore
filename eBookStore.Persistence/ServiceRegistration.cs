using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;
using eBookStore.Persistence.Data;
using eBookStore.Persistence.PersistanceAssemblyMarker;
using eBookStore.Persistence.Repositories.EntityRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eBookStore.Persistence;

public static class ServiceRegistration
{
    public static void AddDataBase(this IServiceCollection services)
    {
        services.AddDbContext<eBookStoreContext>();
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<eBookStoreContext>()
            .AddDefaultTokenProviders();
    }
    public static void AddPersistenceLayerService(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(typeof(IPersistenceAssemblyMarker).Assembly)
        .AddClasses(@class => @class.Where(type => !type.Name.StartsWith('I')
        && type.Name.EndsWith("Repository")))
        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
        .AsImplementedInterfaces()
        .WithScopedLifetime());
    }
}
