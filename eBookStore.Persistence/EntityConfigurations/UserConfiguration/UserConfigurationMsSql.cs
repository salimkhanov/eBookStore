using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.UserConfiguration;

public class UserConfigurationMsSql : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Configurations

        builder.ToTable("Users",DbObject.SchemaNameUsers).HasKey(k => k.Id);

        builder.Property(x => x.EntityStatus)
            .HasColumnName("ENTITY_STATUS")
            .HasColumnType("tinyint");

        #endregion
    }
}
