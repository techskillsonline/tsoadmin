using Microsoft.EntityFrameworkCore.Migrations;

namespace admin.Migrations
{
    public partial class UserFunctionalityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseId",
                table: "CourseDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDiscounts_Discounts_DiscountId",
                table: "CourseDiscounts");

            migrationBuilder.AddColumn<string>(
                name: "UserDesc",
                table: "User",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "DiscountId",
                table: "CourseDiscounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "CourseDiscounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseId",
                table: "CourseDiscounts",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDiscounts_Discounts_DiscountId",
                table: "CourseDiscounts",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseId",
                table: "CourseDiscounts");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDiscounts_Discounts_DiscountId",
                table: "CourseDiscounts");

            migrationBuilder.DropColumn(
                name: "UserDesc",
                table: "User");

            migrationBuilder.AlterColumn<long>(
                name: "DiscountId",
                table: "CourseDiscounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CourseId",
                table: "CourseDiscounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDiscounts_Courses_CourseId",
                table: "CourseDiscounts",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDiscounts_Discounts_DiscountId",
                table: "CourseDiscounts",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
