using Azure.Core;
using eBookStore.Domain.Entities;
using eBookStore.Persistence.EFContext.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eBookStore.Persistence.EFContext;

public class AppDbContext : IdentityDbContext<User, Role, int>
{
    public DbSet<Book> Books { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Cart> Carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-3QONI5I\SQLEXPRESS;Database=EbookStoreDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seeder();
        base.OnModelCreating(modelBuilder);
    }
}
