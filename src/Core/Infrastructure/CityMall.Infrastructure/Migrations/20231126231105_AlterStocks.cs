using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityMall.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterStocks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Stocks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Governorate",
                table: "Stocks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SereetName",
                table: "Stocks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Stocks",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Governorate",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "SereetName",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Stocks");
        }
    }
}
