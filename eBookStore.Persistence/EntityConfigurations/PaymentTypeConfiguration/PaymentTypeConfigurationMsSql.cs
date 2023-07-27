using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.PaymentTypeConfiguration
{
    public class PaymentTypeConfigurationMsSql : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            #region BaseConfigurations

            builder.ToTable("PaymentTypes", DbObject.SchemaNamePaymentTypes).HasKey(k => k.Id);

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

            builder.Property(x => x.Value)
                .HasColumnName("VALUE")
                .HasColumnType("nvarchar(50)");

            #endregion

            #region Relations

            builder.HasMany(x => x.UserPaymentMethod)
                .WithOne(x => x.PaymentType)
                .HasForeignKey(x => x.PaymentTypeId);

            #endregion
        }
    }
}
