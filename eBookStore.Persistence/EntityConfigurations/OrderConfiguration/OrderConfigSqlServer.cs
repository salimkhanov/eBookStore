using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.OrderConfiguration;

public class OrderConfigSqlServer : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        #region Configuration
        builder.ToTable("Order", DbObject.SchemaNameOrders).HasKey(k => k.Id);

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
            Property(x => x.OrderDate).
            HasColumnName("OrderDate").
            HasColumnType("datetime").IsRequired();

        builder.
            Property(x => x.Shipdate).
            HasColumnName("Shipdate").
            HasColumnType("datetime").IsRequired();

        builder.
            Property(x => x.ShipStreet).
            HasColumnName("ShipStreet").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        builder.
            Property(x => x.ShipCity).
            HasColumnName("ShipCity").
            HasColumnType("varchar").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.UserId).
            HasColumnName("UserId").
            HasColumnType("int").
            HasMaxLength(10).IsRequired();

        builder.
            Property(x => x.User).
            HasColumnName("User").
            HasColumnType("varchar").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.OrderProducts).
            HasColumnName("OrderProducts").
            HasColumnType("nvarchar(max)").
            IsRequired();

        #endregion
    }
}
