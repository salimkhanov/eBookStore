using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.OrderProductConfiguration;

public class OrderProductConfigSqlServer : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        #region Configuration
        builder.HasKey(x => new { x.OrderId, x.ProductId });

        builder.
            Property(x => x.ProductQuantity).
            HasColumnName("ProductQuantity").
            HasColumnType("int").
            IsRequired();



        #endregion
    }
}
