using eBookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace eBookStore.Persistence.EFContext.SeedData;

public static partial class DataSeeder
{
    public static void Seeder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookGenre>().HasData(BookGenreSeeder());
        modelBuilder.Entity<BookLanguage>().HasData(BookLanguageSeeder());
        modelBuilder.Entity<Country>().HasData(CountrySeeder());
        modelBuilder.Entity<OrderStatus>().HasData(OrderStatusSeeder());
        modelBuilder.Entity<PaymentMethod>().HasData(PaymentMethodSeeder());
        modelBuilder.Entity<ShippingMethod>().HasData(ShippingMethodSeeder());
        modelBuilder.Entity<Author>().HasData(AuthorSeeder());
        modelBuilder.Entity<Publisher>().HasData(PublisherSeeder());
    }
}
