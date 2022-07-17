using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishMarket.Infrastructure.Migrations.ApplicationDb
{
    public partial class FishTablePriceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Fishes",
                type: "float",
                maxLength: 200,
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Fishes");
        }
    }
}
