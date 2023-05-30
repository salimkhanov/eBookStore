using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "EntityStatus",
                table: "AspNetUsers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "EntityStatus",
                table: "AspNetRoles",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EntityStatus",
                table: "AspNetRoles");
        }
    }
}
