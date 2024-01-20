using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrupSabahAlisveris.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cateogory_Name",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Category_Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id1 = table.Column<int>(type: "int", nullable: true),
                    SubCategory_Id = table.Column<int>(type: "int", nullable: false),
                    SubCategory_Id1 = table.Column<int>(type: "int", nullable: true),
                    Product_Feature = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Category_Id1",
                        column: x => x.Category_Id1,
                        principalTable: "Categories",
                        principalColumn: "Category_Id");
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategory_Id1",
                        column: x => x.SubCategory_Id1,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategory_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_Id1",
                table: "Products",
                column: "Category_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategory_Id1",
                table: "Products",
                column: "SubCategory_Id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropColumn(
                name: "Category_Name",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Cateogory_Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
