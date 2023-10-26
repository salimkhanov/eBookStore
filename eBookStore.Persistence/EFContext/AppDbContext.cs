using eBookStore.Domain.Entities;
using eBookStore.Persistence.EFContext.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Persistence.EFContext;

public class AppDbContext : IdentityDbContext<User, Role, int>
{
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Cart> Carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-3QONI5I\SQLEXPRESS;Database=EbookStoreDb;Trusted_Connection=True;TrustServerCertificate=True;");
        optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(user => user.Addresses)
            .WithOne(address => address.User)
            .HasForeignKey(address => address.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(user => user.PaymentMethods)
            .WithOne(paymentMethod => paymentMethod.User)
            .HasForeignKey(paymentMethod => paymentMethod.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Seeder();
        base.OnModelCreating(modelBuilder);
    }
}
