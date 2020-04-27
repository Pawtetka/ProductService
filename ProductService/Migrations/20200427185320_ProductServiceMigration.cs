using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductService.Migrations
{
    public partial class ProductServiceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInShops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInShops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    ProductCount = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryApplications_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryApplications_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductInStorages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    StorageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInStorages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInStorages_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryObjectModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    DeliveryApplicationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryObjectModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryObjectModels_DeliveryApplications_DeliveryApplicationId",
                        column: x => x.DeliveryApplicationId,
                        principalTable: "DeliveryApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryObjectModels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Product 1" },
                    { 2, "Product 2" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Shop 1" });

            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Storage 1" });

            migrationBuilder.InsertData(
                table: "DeliveryApplications",
                columns: new[] { "Id", "Date", "Name", "Number", "ProductCount", "ShopId", "StorageId" },
                values: new object[,]
                {
                    { 2, "27.12.2000", "Application 2", 321, 2, 1, null },
                    { 1, "15.11.2000", "Application 1", 123, 1, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductInShops",
                columns: new[] { "Id", "ProductId", "ShopId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductInStorages",
                columns: new[] { "Id", "ProductId", "StorageId" },
                values: new object[] { 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "DeliveryObjectModels",
                columns: new[] { "Id", "DeliveryApplicationId", "ProductId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "DeliveryObjectModels",
                columns: new[] { "Id", "DeliveryApplicationId", "ProductId" },
                values: new object[] { 3, 2, 2 });

            migrationBuilder.InsertData(
                table: "DeliveryObjectModels",
                columns: new[] { "Id", "DeliveryApplicationId", "ProductId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryApplications_ShopId",
                table: "DeliveryApplications",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryApplications_StorageId",
                table: "DeliveryApplications",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryObjectModels_DeliveryApplicationId",
                table: "DeliveryObjectModels",
                column: "DeliveryApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryObjectModels_ProductId",
                table: "DeliveryObjectModels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShops_ProductId",
                table: "ProductInShops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInShops_ShopId",
                table: "ProductInShops",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInStorages_ProductId",
                table: "ProductInStorages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInStorages_StorageId",
                table: "ProductInStorages",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryObjectModels");

            migrationBuilder.DropTable(
                name: "ProductInShops");

            migrationBuilder.DropTable(
                name: "ProductInStorages");

            migrationBuilder.DropTable(
                name: "DeliveryApplications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
