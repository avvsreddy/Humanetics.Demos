using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Humanetics.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class dataannotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "tbl_products");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "tbl_products",
                newName: "InStock");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tbl_products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_products",
                table: "tbl_products",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_products",
                table: "tbl_products");

            migrationBuilder.RenameTable(
                name: "tbl_products",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "InStock",
                table: "Products",
                newName: "IsAvailable");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");
        }
    }
}
