﻿using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.AddressConfiguration
{
    public class AddressConfigurationMsSql : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            #region BaseConfigurations

            builder.ToTable("Addresses", DbObject.SchemaNameAddresses).HasKey(k => k.Id);

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

            builder.Property(x => x.UnitNumber)
                .HasColumnName("UNIT_NUMBER")
                .HasColumnType("int");

            builder.Property(x => x.StreetNumber)
                .HasColumnName("STREET_NUMBER")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.AddressLine1)
                .HasColumnName("ADDRESS_LINE1")
                .HasColumnType("nvarchar");

            builder.Property(x => x.AddressLine2)
                .HasColumnName("ADDRESS_LINE2")
                .HasColumnType("nvarchar");

            builder.Property(x => x.City)
                .HasColumnName("CITY")
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.Region)
                .HasColumnName("REGION")
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.PostalCode)
                .HasColumnName("POSTAL_CODE")
                .HasColumnType("nvarchar")
                .IsRequired();

            builder.Property(x => x.CountryId)
                .HasColumnName("COUNTRY_ID")
                .HasColumnType("int");

            #endregion

            #region Relations

            builder.HasOne<Country>(x => x.Country)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.CountryId);

            builder.HasMany(x => x.UserAddress)
            .WithOne(x => x.Address)
            .HasForeignKey(x => x.AddressId);

            #endregion
        }
    }
}