using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.TranslatorConfiguration;

public class TranslatorConfigSqlServer : IEntityTypeConfiguration<Translator>
{
    public void Configure(EntityTypeBuilder<Translator> builder)
    {
        #region Configurations
        builder.ToTable("Translator", DbObject.SchemaNameTranslators).HasKey(k => k.Id);

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
            Property(x => x.FirstName).
            HasColumnName("FirstName").
            HasColumnType("varchar").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.LastName).
            HasColumnName("LastName").
            HasColumnType("varchar").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.Email).
            HasColumnName("Email").
            HasColumnType("nvarchar(max)");

        builder.
            Property(x => x.PhoneNumber).
            HasColumnName("PhoneNumber").
            HasColumnType("varchar").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.Books).
            HasColumnName("Books").
            HasColumnType("nvarchar(max)").
            IsRequired();
        #endregion
    }
}
