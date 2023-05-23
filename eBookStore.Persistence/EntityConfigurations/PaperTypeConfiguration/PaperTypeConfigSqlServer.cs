using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.PaperTypeConfigurations;

public class PaperTypeConfigSqlServer : IEntityTypeConfiguration<PaperType>
{
    public void Configure(EntityTypeBuilder<PaperType> builder)
    {
        #region BaseConfiguration
        builder.ToTable("PaperType", DbObject.SchemaNamePaperTypes).HasKey(k => k.Id);

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
            Property(x => x.PaperTypeName).
            HasColumnName("PaperTypeName").
            HasColumnType("nvarchar").
            HasMaxLength(30).IsRequired();



        #endregion
    }
}
