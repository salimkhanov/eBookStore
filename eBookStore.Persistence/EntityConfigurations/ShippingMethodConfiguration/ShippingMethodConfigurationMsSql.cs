using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.ShippingMethodConfiguration;

public class ShippingMethodConfigurationMsSql : IEntityTypeConfiguration<ShippingMethod>
{
    public void Configure(EntityTypeBuilder<ShippingMethod> builder)
    {
        #region BaseConfiguration

        builder.ToTable("ShippingMethods", DbObject.SchemaNameShippingMethods).HasKey(k => k.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UPDATED_AT");

        builder.Property(x => x.EntityStatus)
            .HasColumnName("ENTITY_STATUS")
            .HasColumnType("int");

        #endregion

        #region Configuration

        builder.Property(x => x.Name)
            .HasColumnName("NAME")
            .HasColumnType("nvarchar(120)");

        builder.Property(x => x.Price)
            .HasColumnName("PRICE");

        #endregion

        #region Relations

        builder.HasMany(x => x.ShopOrders)
            .WithOne(x => x.ShippingMethod)
            .HasForeignKey(x => x.ShippingMethodId);

        #endregion
    }
}
