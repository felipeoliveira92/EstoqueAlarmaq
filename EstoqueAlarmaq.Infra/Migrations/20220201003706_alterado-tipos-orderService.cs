using Microsoft.EntityFrameworkCore.Migrations;

namespace EstoqueAlarmaq.Infra.Migrations
{
    public partial class alteradotiposorderService : Migration
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

            migrationBuilder.DropTable(
                name: "Users");

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
                name: "Tec",
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
                name: "Tec",
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
