using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Users",
                table: "Users");
        }
    }
}
