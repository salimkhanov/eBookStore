using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.ShopOrderConfiguration;

public class ShopOrderConfigurationMsSql : IEntityTypeConfiguration<ShopOrder>
{
    public void Configure(EntityTypeBuilder<ShopOrder> builder)
    {
        #region BaseConfiguration

        builder.ToTable("ShopOrders", DbObject.SchemaNameShopOrders).HasKey(x => x.Id);

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

        builder.Property(x => x.UserId)
            .HasColumnName("USER_ID");

        builder.Property(x => x.OrderDate)
            .HasColumnName("ORDER_DATE");

        builder.Property(x => x.UserPaymentMethodId)
            .HasColumnName("USER_PAYMENT_METHOD_ID");

        builder.Property(x => x.AddressId)
            .HasColumnName("ADDRESS_ID");

        builder.Property(x => x.ShippingMethodId)
            .HasColumnName("SHIPPING_METHOD_ID");

        builder.Property(x => x.OrderTotal)
            .HasColumnName("ORDER_TOTAL");

        builder.Property(x => x.OrderStatusId)
            .HasColumnName("ORDER_STATUS_ID");

        #endregion

        #region Relations

        //builder.HasOne(x => x.User)
        //    .WithMany(x => x.ShopOrders)
        //    .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.UserPaymentMethod)
            .WithMany(x => x.ShopOrders)
            .HasForeignKey(x => x.UserPaymentMethodId);

        builder.HasOne(x => x.Address)
            .WithMany(x => x.ShopOrders)
            .HasForeignKey(x => x.AddressId);

        builder.HasOne(x => x.ShippingMethod)
            .WithMany(x => x.ShopOrders)
            .HasForeignKey(x => x.ShippingMethodId);

        builder.HasOne(x => x.OrderStatus)
            .WithMany(x => x.ShopOrders)
            .HasForeignKey(x => x.OrderStatusId);

        #endregion
    }
}
