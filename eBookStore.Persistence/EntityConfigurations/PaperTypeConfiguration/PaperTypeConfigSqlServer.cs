using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.PaperTypeConfigurations;

public class PaperTypeConfigSqlServer : IEntityTypeConfiguration<PaperType>
{
    public void Configure(EntityTypeBuilder<PaperType> builder)
    {
        #region Configuration
        builder.ToTable("PaperType", DbObject.SchemaNamePaperTypes).HasKey(k => k.Id);

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
            Property(x => x.PaperTypeName).
            HasColumnName("PaperTypeName").
            HasColumnType("varchar").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.BookCovers).
            HasColumnName("BookCovers").
            HasColumnType("varchar").
            HasMaxLength(55);

        builder.
            Property(x => x.BookPapers).
            HasColumnName("BookPapers").
            HasColumnType("varchar").
            HasMaxLength(55);

        #endregion
    }
}
