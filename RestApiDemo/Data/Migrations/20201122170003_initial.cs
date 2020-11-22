using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiDemo.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUri", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Hp 110, 2,1 Ghz processor", "products/notebooks/HP/110/img.jpg", "Notebook Hp 110", 5500m },
                    { 19, "Hp 1910, 2,5 Ghz processor", "products/notebooks/HP/1910/img.jpg", "Notebook Hp 1910", 7300m },
                    { 18, "Hp 1810, 2,4 Ghz processor", "products/notebooks/HP/1810/img.jpg", "Notebook Hp 1810", 7200m },
                    { 17, "Hp 1710, 2,3 Ghz processor", "products/notebooks/HP/1710/img.jpg", "Notebook Hp 1710", 7100m },
                    { 16, "Hp 1610, 2,2 Ghz processor", "products/notebooks/HP/1610/img.jpg", "Notebook Hp 1610", 7000m },
                    { 15, "Hp 1510, 2,1 Ghz processor", "products/notebooks/HP/1510/img.jpg", "Notebook Hp 1510", 6900m },
                    { 14, "Hp 1410, 2,7 Ghz processor", "products/notebooks/HP/1410/img.jpg", "Notebook Hp 1410", 6800m },
                    { 13, "Hp 1310, 2,6 Ghz processor", "products/notebooks/HP/1310/img.jpg", "Notebook Hp 1310", 6700m },
                    { 12, "Hp 1210, 2,5 Ghz processor", "products/notebooks/HP/1210/img.jpg", "Notebook Hp 1210", 6600m },
                    { 20, "Hp 2010, 2,6 Ghz processor", "products/notebooks/HP/2010/img.jpg", "Notebook Hp 2010", 7400m },
                    { 11, "Hp 1110, 2,4 Ghz processor", "products/notebooks/HP/1110/img.jpg", "Notebook Hp 1110", 6500m },
                    { 9, "Hp 910, 2,2 Ghz processor", "products/notebooks/HP/910/img.jpg", "Notebook Hp 910", 6300m },
                    { 8, "Hp 810, 2,1 Ghz processor", "products/notebooks/HP/810/img.jpg", "Notebook Hp 810", 6200m },
                    { 7, "Hp 710, 2,7 Ghz processor", "products/notebooks/HP/710/img.jpg", "Notebook Hp 710", 6100m },
                    { 6, "Hp 610, 2,6 Ghz processor", "products/notebooks/HP/610/img.jpg", "Notebook Hp 610", 6000m },
                    { 5, "Hp 510, 2,5 Ghz processor", "products/notebooks/HP/510/img.jpg", "Notebook Hp 510", 5900m },
                    { 4, "Hp 410, 2,4 Ghz processor", "products/notebooks/HP/410/img.jpg", "Notebook Hp 410", 5800m },
                    { 3, "Hp 310, 2,3 Ghz processor", "products/notebooks/HP/310/img.jpg", "Notebook Hp 310", 5700m },
                    { 2, "Hp 210, 2,2 Ghz processor", "products/notebooks/HP/210/img.jpg", "Notebook Hp 210", 5600m },
                    { 10, "Hp 1010, 2,3 Ghz processor", "products/notebooks/HP/1010/img.jpg", "Notebook Hp 1010", 6400m },
                    { 21, "Hp 2110, 2,7 Ghz processor", "products/notebooks/HP/2110/img.jpg", "Notebook Hp 2110", 7500m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
