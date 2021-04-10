using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerCuatro.Migrations
{
    public partial class Virtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Paquetes_ClienteId",
                table: "Paquetes");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_ClienteId",
                table: "Paquetes",
                column: "ClienteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Paquetes_ClienteId",
                table: "Paquetes");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_ClienteId",
                table: "Paquetes",
                column: "ClienteId");
        }
    }
}
