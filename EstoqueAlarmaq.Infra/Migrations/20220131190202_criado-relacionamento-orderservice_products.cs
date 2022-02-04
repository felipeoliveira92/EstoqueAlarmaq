using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAlarmaq.Infra.Migrations
{
    public partial class criadorelacionamentoorderservice_products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderServiceProduct");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "User",
                table: "OrderServices");

            migrationBuilder.AddColumn<int>(
                name: "OrderServicesId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TecnicoId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OrderServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderServicesId",
                table: "Products",
                column: "OrderServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_ClientId",
                table: "OrderServices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_TecnicoId",
                table: "OrderServices",
                column: "TecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_UserId",
                table: "OrderServices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Clients_ClientId",
                table: "OrderServices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Users_TecnicoId",
                table: "OrderServices",
                column: "TecnicoId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Users_UserId",
                table: "OrderServices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderServices_OrderServicesId",
                table: "Products",
                column: "OrderServicesId",
                principalTable: "OrderServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Clients_ClientId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Users_TecnicoId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Users_UserId",
                table: "OrderServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderServices_OrderServicesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderServicesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_ClientId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_TecnicoId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_UserId",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "OrderServicesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "TecnicoId",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderServices");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "OrderServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "OrderServices",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
