using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity_1.Data.Migrations
{
    /// <inheritdoc />
    public partial class FullNameMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "security",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "security",
                table: "User");
        }
    }
}
