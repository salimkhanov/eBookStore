using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init13242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRODUCT_ITEM_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem",
                newName: "BOOK_ITEM_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BOOK_ITEM_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem",
                newName: "PRODUCT_ITEM_ID");
        }
    }
}
