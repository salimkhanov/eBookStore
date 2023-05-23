using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.OrderConfiguration;

public class OrderConfigSqlServer : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        #region BaseConfiguration
        builder.ToTable("Order", DbObject.SchemaNameOrders).HasKey(k => k.Id);

        builder
            .HasKey(k => k.Id);

        builder.
            Property(x => x.Id).
            ValueGeneratedOnAdd().
            HasColumnName("Id").
            HasColumnType("int");

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

        #endregion 

        #region Configuration

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
            HasColumnType("nvarchar").
            HasMaxLength(80).IsRequired();

        builder.
            Property(x => x.ShipCity).
            HasColumnName("ShipCity").
            HasColumnType("varchar").
            HasMaxLength(80).IsRequired();





        #endregion
    }
}
