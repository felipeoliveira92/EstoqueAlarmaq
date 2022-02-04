using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAlarmaq.Infra.Migrations
{
    public partial class alteradocamposparastring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ClientId",
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
                name: "Tecnico",
                table: "OrderServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "OrderServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "Tecnico",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "User",
                table: "OrderServices");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
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
        }
    }
}
