﻿using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.UserConfiguration;

public class UserConfigurationMsSql : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Configurations

        builder.ToTable("Users", DbObject.SchemaNameUsers).HasKey(k => k.Id);

        builder.Property(x => x.FirstName)
            .HasColumnName("FIRST_NAME")
            .HasColumnType("nvarchar")
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnName("LAST_NAME")
            .HasColumnType("nvarchar")
            .IsRequired();

        builder.Property(x => x.EntityStatus)
            .HasColumnName("ENTITY_STATUS")
            .HasColumnType("tinyint");

        #endregion

        #region Relations

        builder.HasMany(x => x.UserAddress)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        #endregion
    }
}
