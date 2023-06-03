using eBookStore.Domain.Entities.Authorizations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace eBookStore.Persistence.Data;

public class eBookStoreContext: IdentityDbContext<User,Role,int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-27PP8UE\\SQLEXPRESS;Database=eBookStore;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); 
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
