using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.RoleConfiguration;

public class RoleConfigSqlServer : IEntityTypeConfiguration<BookStoreRole>
{
    public void Configure(EntityTypeBuilder<BookStoreRole> builder)
    {
        #region Configurations
        builder.ToTable("Role", DbObject.SchemaNameRoles).HasKey(k => k.Id);

        builder.
            Property(x => x.Id).
            HasColumnName("Id").
            HasColumnType("int").
            HasMaxLength(35).IsRequired();
        #endregion

    }
}
