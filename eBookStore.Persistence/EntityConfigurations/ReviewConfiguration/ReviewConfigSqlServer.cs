using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.ReviewConfiguration;
public class ReviewConfigSqlServer : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
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
            Property(x => x.LikeCount).
            HasColumnName("LikeCount").
            HasColumnType("int").
            HasMaxLength(35);

        builder.
            Property(x => x.DislikeCount).
            HasColumnName("DislikeCount").
            HasColumnType("int").
            HasMaxLength(35);

        builder.
            Property(x => x.Content).
            HasColumnName("Content").
            HasColumnType("nvarchar(max)").
            IsRequired();

        builder.
            Property(x => x.UserId).
            HasColumnName("UserId").
            HasColumnType("int").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.User).
            HasColumnName("User").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        builder.
            Property(x => x.ProductId).
            HasColumnName("ProductId").
            HasColumnType("int").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.Product).
            HasColumnName("Product").
            HasColumnType("varchar").
            HasMaxLength(55).IsRequired();

        builder.
            Property(x => x.ReviewId).
            HasColumnName("ReviewId").
            HasColumnType("int").
            HasMaxLength(35).IsRequired();

        builder.
            Property(x => x.ResponseOfReview).
            HasColumnName("ResponseOfReview").
            HasColumnType("nvarchar(max)");

        builder.
            Property(x => x.Reviews).
            HasColumnName("Reviews").
            HasColumnType("nvarchar(max)");
        #endregion

    }
}
