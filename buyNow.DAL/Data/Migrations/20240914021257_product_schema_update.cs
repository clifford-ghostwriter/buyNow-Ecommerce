using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace buyNow_Ecommerce.Data.Migrations
{
    /// <inheritdoc />
    public partial class product_schema_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,4)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ImagerUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                type: "int",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ImagerUrl",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
