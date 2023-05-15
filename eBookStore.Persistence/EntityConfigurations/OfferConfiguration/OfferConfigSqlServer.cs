using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.OfferConfiguration;

public class OfferConfigSqlServer : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        #region Configuration
        builder.ToTable("Offer", DbObject.SchemaNameOffers).HasKey(k => k.Id);

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
            Property(x => x.OfferStartDate).
            HasColumnName("OfferStartDate").
            HasColumnType("datetime").IsRequired();

        builder.
            Property(x => x.OfferEndDate).
            HasColumnName("OfferEndDate").
            HasColumnType("datetime").IsRequired();

        builder.
            Property(x => x.OfferPrice).
            HasColumnName("OfferPrice").
            HasColumnType("varchar").
            HasMaxLength(30).IsRequired();

        builder.
            Property(x => x.OfferContent).
            HasColumnName("OfferContent").
            HasColumnType("varchar").
            HasMaxLength(35);

        builder.
            Property(x => x.ProductId).
            HasColumnName("ProductId").
            HasColumnType("int").
            HasMaxLength(10).IsRequired();

        builder.
            Property(x => x.Product).
            HasColumnName("Product").
            HasColumnType("varchar").
            HasMaxLength(40).IsRequired();

        #endregion
    }
}
