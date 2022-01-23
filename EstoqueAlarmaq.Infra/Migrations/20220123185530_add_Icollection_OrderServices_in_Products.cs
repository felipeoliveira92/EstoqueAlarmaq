using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAlarmaq.Infra.Migrations
{
    public partial class add_Icollection_OrderServices_in_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderServices_OrderServiceId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderServiceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderServiceId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "OrderServiceProduct",
                columns: table => new
                {
                    OrderServicesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServiceProduct", x => new { x.OrderServicesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrderServiceProduct_OrderServices_OrderServicesId",
                        column: x => x.OrderServicesId,
                        principalTable: "OrderServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderServiceProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderServiceProduct_ProductsId",
                table: "OrderServiceProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderServiceProduct");

            migrationBuilder.AddColumn<int>(
                name: "OrderServiceId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderServiceId",
                table: "Products",
                column: "OrderServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderServices_OrderServiceId",
                table: "Products",
                column: "OrderServiceId",
                principalTable: "OrderServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
