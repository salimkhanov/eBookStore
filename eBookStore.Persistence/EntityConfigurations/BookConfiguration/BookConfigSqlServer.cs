using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.BookConfiguration;

public class BookConfigSqlServer : IEntityTypeConfiguration<Book>
{

    public void Configure(EntityTypeBuilder<Book> builder)
    {
        #region BaseConfiguration
        builder.ToTable("Book", DbObject.SchemaNameBooks).HasKey(k => k.Id);

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
            Property(x => x.OriginalName).
            HasColumnName("OriginalName").
            HasColumnType("varchar").
            HasMaxLength(60).IsRequired();

        builder.
           Property(x => x.Summary).
           HasColumnName("Summary").
           HasColumnType("nvarchar").
           HasMaxLength(300).IsRequired();

        builder.
           Property(x => x.PageNumber).
           HasColumnName("PageNumber").
           HasColumnType("int");


        builder.
            Property(x => x.Edition).
            HasColumnName("Edition").
            HasColumnType("tinyint").IsRequired();


        builder.
            Property(x => x.BookHeight).
            HasColumnName("BookHeight").
            HasColumnType("int").IsRequired();

        builder.
            Property(x => x.BookWidth).
            HasColumnName("BookWidth").
            HasColumnType("int").IsRequired();



        #endregion
    }
}
