using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.RoleConfiguration;

public class RoleConfigurationMsSql : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        #region Configurations

        builder.ToTable("Roles",DbObject.SchemaNameRoles).HasKey(x => x.Id);

        builder.Property(x => x.OrderIndex)
            .HasColumnName("ORDER_INDEX")
            .HasColumnType("int");

        builder.Property(x => x.EntityStatus)
            .HasColumnName("ENTITY_STATUS")
            .HasColumnType("tinyint");

        #endregion
    }
}
