using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eBookStore.Persistence.EFContext;

public class AppDbContext : IdentityDbContext<User, Role, int>
{
    //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //{

    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Data Source = DESKTOP - 3QONI5I\SQLEXPRESS; Initial Catalog = eBookStoreDB; Integrated Security = True; TrustServerCertificate = True; ");
    }
}
