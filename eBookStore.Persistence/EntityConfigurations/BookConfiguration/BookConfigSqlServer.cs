using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.BookConfiguration;

public class BookConfigSqlServer : IEntityTypeConfiguration<Book>
{

    public void Configure(EntityTypeBuilder<Book> builder)
    {
        #region Configuration

        builder.ToTable("Book", DbObject.SchemaNameBooks).HasKey(k => k.Id);

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
            Property(x => x.OriginalName).
            HasColumnName("OriginalName").
            HasColumnType("varchar").
            HasMaxLength(30).IsRequired();

        builder.
           Property(x => x.Summary).
           HasColumnName("Summary").
           HasColumnType("varchar").
           HasMaxLength(30).IsRequired();

        builder.
           Property(x => x.PageNumber).
           HasColumnName("PageNumber").
           HasColumnType("int").
           HasMaxLength(10);

        builder.
            Property(x => x.Edition).
            HasColumnName("Edition").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.BookHeight).
            HasColumnName("BookHeight").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.BookWidth).
            HasColumnName("BookWidth").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.Genres).
            HasColumnName("Genres").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.Authors).
            HasColumnName("Authors").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.Translators).
            HasColumnName("Translators").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.LanguageId).
            HasColumnName("LanguageId").
            HasColumnType("int").
            HasMaxLength(10);

        builder.
            Property(x => x.Language).
            HasColumnName("Language").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        
        builder.
            Property(x => x.ProductId).
            HasColumnName("ProductId").
            HasColumnType("int").
            HasMaxLength(10);

        builder.
            Property(x => x.Product).
            HasColumnName("Product").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.CoverTypeId).
            HasColumnName("CoverTypeId").
            HasColumnType("int").
            HasMaxLength(10);

       
        builder.
            Property(x => x.CoverType).
            HasColumnName("CoverType").
            HasColumnType("nvarchar").
            HasMaxLength(35);


        builder.
            Property(x => x.Papertypeid).
            HasColumnName("Papertypeid").
            HasColumnType("int").
            HasMaxLength(10);

        builder.
            Property(x => x.PaperType).
            HasColumnName("PaperType").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        builder.
            Property(x => x.PublisherId).
            HasColumnName("PublisherId").
            HasColumnType("int").
            HasMaxLength(10);

        builder.
            Property(x => x.Publisher).
            HasColumnName("Publisher").
            HasColumnType("nvarchar").
            HasMaxLength(35);

        #endregion
    }
}
