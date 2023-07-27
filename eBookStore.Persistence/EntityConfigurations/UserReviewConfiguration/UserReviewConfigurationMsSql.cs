using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.UserReviewConfiguration;

public class UserReviewConfigurationMsSql : IEntityTypeConfiguration<UserReview>
{
    public void Configure(EntityTypeBuilder<UserReview> builder)
    {
        #region BaseConfigurations

        builder.ToTable("UserReviews", DbObject.SchemaNameUserReviews).HasKey(k => k.Id);

        builder.Property(x => x.Id)
            .HasColumnName("ID");

        builder.Property(x => x.CreatedAt)
            .HasColumnName("CREATED_AT");

        builder.Property(x => x.UpdatedAt)
            .HasColumnName("UPDATED_AT");

        builder.Property(x => x.EntityStatus)
            .HasColumnName("ENTITY_STATUS")
            .HasColumnType("int");

        #endregion

        #region Configurations

        builder.Property(x => x.UserId)
            .HasColumnName("USER_ID");

        builder.Property(x => x.OrderLineId)
            .HasColumnName("ORDER_LINE_ID");

        builder.Property(x => x.RatingValue)
            .HasColumnName("RATING_VALUE");

        builder.Property(x => x.Comment)
            .HasColumnName("COMMENT")
            .HasColumnType("nvarchar(max)");

        #endregion

        #region Relations

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserReview)
            .HasForeignKey(x => x.UserId);

        #endregion
    }
}
