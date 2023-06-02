using eBookStore.Domain.Entities;
using eBookStore.Persistence.EFContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eBookStore.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceLayerService(this IServiceCollection services)
    {
        //services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(@"Data Source=DESKTOP-3QONI5I\SQLEXPRESS;Initial Catalog=eBookStoreDB ;Integrated Security=True;TrustServerCertificate=True;"); });

        //services.AddIdentity<User, Role>()
        //        .AddEntityFrameworkStores<AppDbContext>()
        //        .AddDefaultTokenProviders();
    }
}
