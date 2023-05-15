using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.ProductConfiguration;

public class ProductConfigSqlServer : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        #region Configuration
        builder.ToTable("Product", DbObject.SchemaNameProducts).HasKey(k => k.Id);

        builder.
            Property(x => x.Id).
            HasColumnName("Id").
            HasColumnType("int").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.CreateDate).
            HasColumnName("CreateDate").
            HasDefaultValueSql("getdate()");

        builder.
            Property(x => x.UpdateDate).
            HasColumnName("UpdateDate").
            HasDefaultValueSql("getdate()");

        builder.
            Property(x => x.CreateByName).
            HasColumnName("CreateByName").
            HasColumnType("varchar").
            HasMaxLength(30).IsRequired();

        builder.
            Property(x => x.UpdateByName).
            HasColumnName("UpdateByName").
            HasColumnType("varchar").
            HasMaxLength(30).IsRequired();

        builder.
            Property(x => x.EntityStatus).
            HasColumnName("EntityStatus").
            HasColumnType("int").
            HasMaxLength(1).IsRequired();

        builder.
            Property(x => x.Note).
            HasColumnName("Note").
            HasColumnType("nvarchar(max)").
            IsRequired();

        builder.
            Property(x => x.Price).
            HasColumnName("Price").
            HasColumnType("float").
            HasMaxLength(20).IsRequired();

        builder.
            Property(x => x.StockCount).
            HasColumnName("StockCount").
            HasColumnType("int").
            HasMaxLength(15);

        builder.
            Property(x => x.SoldCount).
            HasColumnName("SoldCount").
            HasColumnType("int").
            HasMaxLength(35);

        builder.
            Property(x => x.Book).
            HasColumnName("Book").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        builder.
            Property(x => x.User).
            HasColumnName("User").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        builder.
            Property(x => x.OrderProducts).
            HasColumnName("OrderProducts").
            HasColumnType("nvarchar(max)").
            IsRequired();

        builder.
            Property(x => x.Offers).
            HasColumnName("Offers").
            HasColumnType("nvarchar(max)");

        builder.
            Property(x => x.Reviews).
            HasColumnName("Reviews").
            HasColumnType("nvarchar(max)");
        #endregion

    }
}
