using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.CountryConfiguration
{
    public class CountryConfigurationMsSql : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            #region BaseConfigurations

            builder.ToTable("Countries", DbObject.SchemaNameCountries).HasKey(k => k.Id);

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

            builder.Property(x => x.CountryName)
                .HasColumnName("COUNTRY_NAME")
                .HasColumnType("nvarchar(30)")
                .IsRequired();

            #endregion

            #region Relations

            builder.HasMany(x => x.Addresses)
            .WithOne(x => x.Country)
            .HasForeignKey(x => x.CountryId);

            #endregion
        }
    }
}
