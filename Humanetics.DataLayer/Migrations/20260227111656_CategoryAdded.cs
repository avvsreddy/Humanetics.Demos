using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Humanetics.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "tbl_products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_CategoryId",
                table: "tbl_products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_products_Categories_CategoryId",
                table: "tbl_products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_products_Categories_CategoryId",
                table: "tbl_products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_tbl_products_CategoryId",
                table: "tbl_products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "tbl_products");
        }
    }
}
