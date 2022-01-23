using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAlarmaq.Infra.Migrations
{
    public partial class add_IcollectionProducts_OrderServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Products",
                table: "OrderServices");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Products",
                table: "OrderServices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
