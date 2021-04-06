using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerCuatro.Migrations
{
    public partial class Otro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaTransportadora",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "TipoDeMercancia",
                table: "Paquetes");

            migrationBuilder.AddColumn<int>(
                name: "TipoMercanciaId",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransportadoraId",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_TipoMercanciaId",
                table: "Paquetes",
                column: "TipoMercanciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_TransportadoraId",
                table: "Paquetes",
                column: "TransportadoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paquetes_TiposMercancias_TipoMercanciaId",
                table: "Paquetes",
                column: "TipoMercanciaId",
                principalTable: "TiposMercancias",
                principalColumn: "TipoMercanciaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Paquetes_Transportadoras_TransportadoraId",
                table: "Paquetes",
                column: "TransportadoraId",
                principalTable: "Transportadoras",
                principalColumn: "TransportadoraId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paquetes_TiposMercancias_TipoMercanciaId",
                table: "Paquetes");

            migrationBuilder.DropForeignKey(
                name: "FK_Paquetes_Transportadoras_TransportadoraId",
                table: "Paquetes");

            migrationBuilder.DropIndex(
                name: "IX_Paquetes_TipoMercanciaId",
                table: "Paquetes");

            migrationBuilder.DropIndex(
                name: "IX_Paquetes_TransportadoraId",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "TipoMercanciaId",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "TransportadoraId",
                table: "Paquetes");

            migrationBuilder.AddColumn<string>(
                name: "EmpresaTransportadora",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDeMercancia",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
