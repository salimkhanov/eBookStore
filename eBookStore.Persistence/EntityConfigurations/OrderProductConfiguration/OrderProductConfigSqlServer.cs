﻿using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.OrderProductConfiguration;

public class OrderProductConfigSqlServer : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        #region Configuration
        builder.ToTable("OrderProduct", DbObject.SchemaNameOrderProducts).HasKey(k => k.Id);

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
            Property(x => x.ProductQuantity).
            HasColumnName("ProductQuantity").
            HasColumnType("int").HasMaxLength(10).
            IsRequired();

        builder.
            Property(x => x.OrderId).
            HasColumnName("OrderId").
            HasColumnType("int").HasMaxLength(10).
            IsRequired();

        builder.
            Property(x => x.Order).
            HasColumnName("Order").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        builder.
            Property(x => x.ProductId).
            HasColumnName("ProductId").
            HasColumnType("int").
            HasMaxLength(10).IsRequired();

        builder.
            Property(x => x.Product).
            HasColumnName("Product").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        #endregion
        ;
    }
}
