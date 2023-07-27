using eBookStore.Domain.Entities;
using eBookStore.Persistence.DbObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eBookStore.Persistence.EntityConfigurations.ShoppingCartItemConfiguration;

public class ShoppingCartItemConfigurationMsSql : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        #region BaseConfiguration

        builder.ToTable("ShoppingCartItems", DbObject.SchemaNameShoppingCartItems).HasKey(k => k.Id);

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

        builder.Property(x => x.CartId)
            .HasColumnName("CART_ID");

        builder.Property(x => x.BookItemId)
            .HasColumnName("BOOK_ITEM_ID");

        builder.Property(x => x.Quantity)
            .HasColumnName("QUANTITY");

        #endregion

        #region Relations

        builder.HasOne(x => x.ShoppingCart)
            .WithMany(x => x.ShoppingCartItem)
            .HasForeignKey(x => x.CartId);

        #endregion
    }
}
