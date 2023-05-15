using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.AuthorConfiguration;

public class AuthorConfigSqlServer : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        #region Configuration

        builder.ToTable("Author", DbObject.SchemaNameAuthors).HasKey(k => k.Id);

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
            HasMaxLength(30).IsRequired();

        builder.
           Property(x => x.LastName).
           HasColumnName("LastName").
           HasColumnType("varchar").
           HasMaxLength(30).IsRequired();

        builder.
           Property(x => x.Resume).
           HasColumnName("Resume").
           HasColumnType("nvarchar").
           HasMaxLength(35);

        builder.
            Property(x => x.Email).
            HasColumnName("Email").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.Instagram).
            HasColumnName("Instagram").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.Facebook).
            HasColumnName("Facebook").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.Tvitter).
            HasColumnName("Tvitter").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.Genres).
            HasColumnName("Genres").
            HasColumnType("nvarchar").
            HasMaxLength(55);

        builder.
            Property(x => x.Books).
            HasColumnName("Books").
            HasColumnType("nvarchar").
            HasMaxLength(55);

        #endregion
    }
}
