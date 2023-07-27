﻿using eBookStore.Domain.Entities;
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

            builder.Property(x => x.IsDefault)
                .HasColumnName("IS_DEFAULT");

            #endregion

            #region Relations

            builder.HasOne(x => x.User)
            .WithMany(x => x.UserAddress)
            .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Address)
            .WithMany(x => x.UserAddress)
            .HasForeignKey(x => x.AddressId);

            #endregion
        }
    }
}
