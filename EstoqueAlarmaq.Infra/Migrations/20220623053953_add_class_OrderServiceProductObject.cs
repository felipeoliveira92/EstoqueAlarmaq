using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAlarmaq.Infra.Migrations
{
    public partial class add_class_OrderServiceProductObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderServiceProductObject",
                columns: table => new
                {
                    IdOrderServiceProductObject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrderService = table.Column<int>(type: "int", nullable: false),
                    OrderServiceId = table.Column<int>(type: "int", nullable: true),
                    IdProductObject = table.Column<int>(type: "int", nullable: false),
                    ProductObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderServiceProductObject", x => x.IdOrderServiceProductObject);
                    table.ForeignKey(
                        name: "FK_OrderServiceProductObject_OrderServices_OrderServiceId",
                        column: x => x.OrderServiceId,
                        principalTable: "OrderServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderServiceProductObject_ProductsObjects_ProductObjectId",
                        column: x => x.ProductObjectId,
                        principalTable: "ProductsObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderServiceProductObject_OrderServiceId",
                table: "OrderServiceProductObject",
                column: "OrderServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServiceProductObject_ProductObjectId",
                table: "OrderServiceProductObject",
                column: "ProductObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderServiceProductObject");
        }
    }
}
