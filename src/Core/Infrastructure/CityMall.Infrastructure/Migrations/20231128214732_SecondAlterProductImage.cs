using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityMall.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondAlterProductImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ProductImages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ProductImages",
                type: "datetime2",
                nullable: true);
        }
    }
}
