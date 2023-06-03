using eBookStore.Domain.Entities;
using eBookStore.Domain.Entities.Authorizations;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.UserAddressConfiguration
{
    public class UserAddressConfigurationMsSql : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            #region BaseConfigurations

            builder.ToTable("UsersAddresses", DbObject.SchemaNameUsersAddresses).HasKey(k => k.Id);

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

            builder.Property(x => x.AddressId)
                .HasColumnName("ADDRESS_ID");

            #endregion

            #region Relations

            builder.HasOne<User>(x => x.User)
            .WithMany(x => x.UserAddress)
            .HasForeignKey(x => x.UserId);

            builder.HasOne<Address>(x => x.Address)
            .WithMany(x => x.UserAddress)
            .HasForeignKey(x => x.AddressId);

            #endregion
        }
    }
}
