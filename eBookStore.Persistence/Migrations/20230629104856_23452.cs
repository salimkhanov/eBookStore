using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _23452 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PaymentTypes");

            migrationBuilder.EnsureSchema(
                name: "ShoppingCartItems");

            migrationBuilder.EnsureSchema(
                name: "ShoppingCarts");

            migrationBuilder.EnsureSchema(
                name: "UserPaymentMethods");

            migrationBuilder.EnsureSchema(
                name: "UserReviews");

            migrationBuilder.EnsureSchema(
                name: "UserAdresses");

            migrationBuilder.RenameTable(
                name: "UsersAddresses",
                schema: "UsersAdresses",
                newName: "UsersAddresses",
                newSchema: "UserAdresses");

            migrationBuilder.RenameTable(
                name: "UserReviews",
                schema: "UserReview",
                newName: "UserReviews",
                newSchema: "UserReviews");

            migrationBuilder.RenameTable(
                name: "UserPaymentMethods",
                schema: "UserPaymentMethod",
                newName: "UserPaymentMethods",
                newSchema: "UserPaymentMethods");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                schema: "ShoppingCart",
                newName: "ShoppingCarts",
                newSchema: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                schema: "ShoppingCartItem",
                newName: "ShoppingCartItems",
                newSchema: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "PaymentTypes",
                schema: "PaymentType",
                newName: "PaymentTypes",
                newSchema: "PaymentTypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PaymentType");

            migrationBuilder.EnsureSchema(
                name: "ShoppingCartItem");

            migrationBuilder.EnsureSchema(
                name: "ShoppingCart");

            migrationBuilder.EnsureSchema(
                name: "UserPaymentMethod");

            migrationBuilder.EnsureSchema(
                name: "UserReview");

            migrationBuilder.EnsureSchema(
                name: "UsersAdresses");

            migrationBuilder.RenameTable(
                name: "UsersAddresses",
                schema: "UserAdresses",
                newName: "UsersAddresses",
                newSchema: "UsersAdresses");

            migrationBuilder.RenameTable(
                name: "UserReviews",
                schema: "UserReviews",
                newName: "UserReviews",
                newSchema: "UserReview");

            migrationBuilder.RenameTable(
                name: "UserPaymentMethods",
                schema: "UserPaymentMethods",
                newName: "UserPaymentMethods",
                newSchema: "UserPaymentMethod");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                schema: "ShoppingCarts",
                newName: "ShoppingCarts",
                newSchema: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                schema: "ShoppingCartItems",
                newName: "ShoppingCartItems",
                newSchema: "ShoppingCartItem");

            migrationBuilder.RenameTable(
                name: "PaymentTypes",
                schema: "PaymentTypes",
                newName: "PaymentTypes",
                newSchema: "PaymentType");
        }
    }
}
