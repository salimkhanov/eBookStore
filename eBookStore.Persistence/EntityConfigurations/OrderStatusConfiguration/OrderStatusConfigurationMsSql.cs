using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.OrderStatusConfiguration;

public class OrderStatusConfigurationMsSql : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        #region BaseConfigurations

        builder.ToTable("OrderStatus", DbObject.SchemaNameOrderStatus).HasKey(k => k.Id);

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

        #region Configurations

        builder.Property(x => x.Status)
            .HasColumnName("STATUS")
            .HasColumnType("nvarchar(100)");

        #endregion

        #region Relations

        #endregion
    }
}
