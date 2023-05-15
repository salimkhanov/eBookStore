using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.PublisherConfiguration;

/*         public string PublisherName { get; set; }
    public ICollection<Book> Books { get; set; }*/
public class PublisherConfigSqlServer : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        #region Configurations
        builder.ToTable("Publisher", DbObject.SchemaNamePublishers).HasKey(k => k.Id);

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
            Property(x => x.PublisherName).
            HasColumnName("PublisherName").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        builder.
            Property(x => x.Books).
            HasColumnName("Books").
            HasColumnType("nvarchar(max)").
            IsRequired();

        #endregion
    }
}
