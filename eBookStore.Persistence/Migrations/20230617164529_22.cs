using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eBookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COUNTRY",
                schema: "Countries",
                table: "Countries",
                newName: "COUNTRY_NAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COUNTRY_NAME",
                schema: "Countries",
                table: "Countries",
                newName: "COUNTRY");
        }
    }
}
