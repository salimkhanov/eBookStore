using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.ShoppingCartConfiguration;

public class ShoppingCartConfigurationMsSql : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        #region BaseConfiguration

        builder.ToTable("ShoppingCarts", DbObject.SchemaNameShoppingCart).HasKey(k => k.Id);

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

        #region Configuration

        builder.Property(x => x.UserId)
            .HasColumnName("USER_ID");

        #endregion

        #region Relations

        builder.HasOne<User>(x => x.User)
            .WithMany(x => x.ShoppingCart)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.ShoppingCartItem)
            .WithOne(x => x.ShoppingCart)
            .HasForeignKey(x => x.CartId);

        #endregion
    }
}
