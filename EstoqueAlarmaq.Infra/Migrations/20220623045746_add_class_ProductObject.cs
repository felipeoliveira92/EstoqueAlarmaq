using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAlarmaq.Infra.Migrations
{
    public partial class add_class_ProductObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderServices_OrderServicesId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderServicesId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderServicesId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Products",
                newName: "Amount");

            migrationBuilder.CreateTable(
                name: "ProductsObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductsObjects_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsObjects_ProductId",
                table: "ProductsObjects",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsObjects");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Products",
                newName: "Quantidade");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderServicesId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderServicesId",
                table: "Products",
                column: "OrderServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderServices_OrderServicesId",
                table: "Products",
                column: "OrderServicesId",
                principalTable: "OrderServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
