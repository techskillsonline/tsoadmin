using Microsoft.EntityFrameworkCore.Migrations;

namespace admin.Migrations
{
    public partial class Updated_CourseDiscount_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppliedCourseDiscount",
                table: "OrderItem",
                newName: "CourseDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CourseDiscountId",
                table: "OrderItem",
                column: "CourseDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_CourseDiscounts_CourseDiscountId",
                table: "OrderItem",
                column: "CourseDiscountId",
                principalTable: "CourseDiscounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_CourseDiscounts_CourseDiscountId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_CourseDiscountId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "CourseDiscountId",
                table: "OrderItem",
                newName: "AppliedCourseDiscount");
        }
    }
}
