using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _3456 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "OrderStatus");

            migrationBuilder.EnsureSchema(
                name: "ShippingMethods");

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                schema: "OrderStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STATUS = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShippingMethods",
                schema: "ShippingMethods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(120)", nullable: false),
                    PRICE = table.Column<double>(type: "float", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ENTITY_STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingMethods", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStatus",
                schema: "OrderStatus");

            migrationBuilder.DropTable(
                name: "ShippingMethods",
                schema: "ShippingMethods");
        }
    }
}
