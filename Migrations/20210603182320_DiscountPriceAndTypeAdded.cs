using Microsoft.EntityFrameworkCore.Migrations;

namespace admin.Migrations
{
    public partial class DiscountPriceAndTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPrice",
                table: "Discounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DiscountPriceType",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountPriceType",
                table: "Discounts");
        }
    }
}
