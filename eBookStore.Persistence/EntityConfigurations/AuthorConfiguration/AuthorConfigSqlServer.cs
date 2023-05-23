using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.AuthorConfiguration;

//public class AuthorConfigSqlServer : IEntityTypeConfiguration<Author>
//{
//    public void Configure(EntityTypeBuilder<Author> builder)
//    {
//        #region BaseConfiguration

//        builder.ToTable("Author", DbObject.SchemaNameAuthors).HasKey(k => k.Id);

//        builder
//           .HasKey(k => k.Id);

//        builder.
//            Property(x => x.Id).
//            ValueGeneratedOnAdd().
//            HasColumnName("Id").
//            HasColumnType("int");


//        builder.
//            Property(x => x.CreateDate).
//            HasColumnName("CreateDate").
//            HasDefaultValueSql("getdate()");

//        builder.
//            Property(x => x.UpdateDate).
//            HasColumnName("UpdateDate").
//            HasDefaultValueSql("getdate()");

//        builder.
//            Property(x => x.CreateByName).
//            HasColumnName("CreateByName").
//            HasColumnType("nvarchar").
//            HasMaxLength(30).
//            IsRequired();

//        builder.
//            Property(x => x.UpdateByName).
//            HasColumnName("UpdateByName").
//            HasColumnType("nvarchar").
//            HasMaxLength(30).
//            IsRequired();

//        builder.
//            Property(x => x.EntityStatus).
//            HasColumnName("EntityStatus").
//            HasColumnType("tinyint").
//            IsRequired();

//        builder.
//            Property(x => x.Note).
//            HasColumnName("Note").
//            HasColumnType("nvarchar(300)").
//            HasMaxLength(300).
//            IsRequired(false);

//        #endregion

//        #region Configuration

//        builder.
//            Property(x => x.FirstName).
//            HasColumnName("FirstName").
//            HasColumnType("nvarchar").
//            HasMaxLength(30).
//            IsRequired();

//        builder.
//           Property(x => x.LastName).
//           HasColumnName("LastName").
//           HasColumnType("nvarchar").
//           HasMaxLength(30).
//           IsRequired();

//        builder.
//           Property(x => x.Resume).
//           HasColumnName("Resume").
//           HasColumnType("nvarchar").
//           HasMaxLength(300).
//           IsRequired();

//        builder.
//            Property(x => x.Email).
//            HasColumnName("Email").
//            HasColumnType("nvarchar").
//            HasMaxLength(40).
//            IsRequired();

//        builder.
//            Property(x => x.Instagram).
//            HasColumnName("Instagram").
//            HasColumnType("nvarchar").
//            HasMaxLength(40).
//            IsRequired(false);

//        builder.
//            Property(x => x.Facebook).
//            HasColumnName("Facebook").
//            HasColumnType("nvarchar").
//            HasMaxLength(40).
//            IsRequired(false);

//        builder.
//            Property(x => x.Tvitter).
//            HasColumnName("Tvitter").
//            HasColumnType("nvarchar").
//            HasMaxLength(40).
//            IsRequired(false);



//        #endregion
//    }
//}
