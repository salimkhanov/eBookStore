using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1231 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Users_USER_ID",
                schema: "ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_CART_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItem",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                schema: "ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.EnsureSchema(
                name: "PaymentType");

            migrationBuilder.EnsureSchema(
                name: "UserPaymentMethod");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItem",
                schema: "ShoppingCartItem",
                newName: "ShoppingCartItems",
                newSchema: "ShoppingCartItem");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                schema: "ShoppingCart",
                newName: "ShoppingCarts",
                newSchema: "ShoppingCart");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItem_CART_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_CART_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCart_USER_ID",
                schema: "ShoppingCart",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItems",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                schema: "ShoppingCart",
                table: "ShoppingCarts",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                schema: "PaymentType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VALUE = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentMethods",
                schema: "UserPaymentMethod",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    PAYMENT_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    PROVIDER = table.Column<string>(type: "nvarchar(70)", nullable: false),
                    ACCOUNT_NUMBER = table.Column<int>(type: "int", nullable: false),
                    EXPIRY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IS_DEFAULT = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentMethods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_PaymentTypes_PAYMENT_TYPE_ID",
                        column: x => x.PAYMENT_TYPE_ID,
                        principalSchema: "PaymentType",
                        principalTable: "PaymentTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPaymentMethods_Users_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_PAYMENT_TYPE_ID",
                schema: "UserPaymentMethod",
                table: "UserPaymentMethods",
                column: "PAYMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_USER_ID",
                schema: "UserPaymentMethod",
                table: "UserPaymentMethods",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_CART_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItems",
                column: "CART_ID",
                principalSchema: "ShoppingCart",
                principalTable: "ShoppingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Users_USER_ID",
                schema: "ShoppingCart",
                table: "ShoppingCarts",
                column: "USER_ID",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_CART_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Users_USER_ID",
                schema: "ShoppingCart",
                table: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "UserPaymentMethods",
                schema: "UserPaymentMethod");

            migrationBuilder.DropTable(
                name: "PaymentTypes",
                schema: "PaymentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                schema: "ShoppingCart",
                table: "ShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                schema: "ShoppingCart",
                newName: "ShoppingCart",
                newSchema: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                schema: "ShoppingCartItem",
                newName: "ShoppingCartItem",
                newSchema: "ShoppingCartItem");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_USER_ID",
                schema: "ShoppingCart",
                table: "ShoppingCart",
                newName: "IX_ShoppingCart_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_CART_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem",
                newName: "IX_ShoppingCartItem_CART_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                schema: "ShoppingCart",
                table: "ShoppingCart",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItem",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Users_USER_ID",
                schema: "ShoppingCart",
                table: "ShoppingCart",
                column: "USER_ID",
                principalSchema: "Users",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_CART_ID",
                schema: "ShoppingCartItem",
                table: "ShoppingCartItem",
                column: "CART_ID",
                principalSchema: "ShoppingCart",
                principalTable: "ShoppingCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
