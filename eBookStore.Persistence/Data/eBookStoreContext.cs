using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eBookStore.Persistence.Data;

public class eBookStoreContext:IdentityDbContext<User,Role,string>
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<PaperType> PaperTypes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Review> Reviews { get; set; }   
    public DbSet<Translator> Translators { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-VDJMII7;Database=DemoDay;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Book>().HasOne<PaperType>(x => x.CoverType).WithMany(x => x.BookCovers).HasForeignKey(x => x.CoverTypeId).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Book>().HasOne<PaperType>(x => x.PaperType).WithMany(x => x.BookPapers).HasForeignKey(x => x.Papertypeid).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Product>().HasMany<OrderProduct>(x=>x.OrderProducts).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Product>().HasMany<Review>(x => x.Reviews).WithOne(x => x.Product).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Review>().HasMany<Review>(x => x.Reviews).WithOne(x => x.ResponseOfReview).HasForeignKey(x => x.ReviewId).OnDelete(DeleteBehavior.NoAction);

    }
}

