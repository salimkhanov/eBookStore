using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init1324 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ShoppingCartItem");

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                schema: "ShoppingCartItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CART_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCT_ITEM_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<int>(type: "int", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCart_CART_ID",
                        column: x => x.CART_ID,
                        principalSchema: "ShoppingCart",
                        principalTable: "ShoppingCart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_CART_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem",
                column: "CART_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItem",
                schema: "ShoppingCartItem");
        }
    }
}
