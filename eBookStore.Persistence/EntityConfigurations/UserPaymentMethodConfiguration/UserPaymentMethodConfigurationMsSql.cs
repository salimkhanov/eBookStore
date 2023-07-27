using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.UserPaymentMethodConfiguration
{
    public class UserPaymentMethodConfigurationMsSql : IEntityTypeConfiguration<UserPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<UserPaymentMethod> builder)
        {
            #region BaseConfigurations

            builder.ToTable("UserPaymentMethods", DbObject.SchemaNameUserPaymentMethods).HasKey(k => k.Id);

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

            builder.Property(x => x.PaymentTypeId)
                .HasColumnName("PAYMENT_TYPE_ID");

            builder.Property(x => x.Provider)
                .HasColumnName("PROVIDER")
                .HasColumnType("nvarchar(70)");

            builder.Property(x => x.AccountNumber)
                .HasColumnName("ACCOUNT_NUMBER");

            builder.Property(x => x.ExpiryDate)
                .HasColumnName("EXPIRY_DATE");

            builder.Property(x => x.IsDefault)
                .HasColumnName("IS_DEFAULT");

            #endregion

            #region Relations

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserPaymentMethod)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.PaymentType)
                .WithMany(x => x.UserPaymentMethod)
                .HasForeignKey(x => x.PaymentTypeId);

            builder.HasMany(x => x.ShopOrders)
                .WithOne(x => x.UserPaymentMethod)
                .HasForeignKey(x => x.UserPaymentMethodId);

            #endregion
        }
    }
}
