﻿using eBookStore.Persistence.EFContext;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace eBookStore.Persistence;

public static class ServiceRegistration
{
    public static void AddContext(this IServiceCollection services)     
    {
        services.AddDbContext<AppDbContext>();
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
