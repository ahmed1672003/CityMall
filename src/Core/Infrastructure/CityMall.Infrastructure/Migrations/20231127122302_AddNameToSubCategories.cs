using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityMall.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToSubCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SubCategories",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SubCategories");
        }
    }
}
