using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerCuatro.Migrations
{
    public partial class AtributosPaquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Paquetes");

            migrationBuilder.AddColumn<string>(
                name: "CodigoMIA",
                table: "Paquetes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpresaTransportadora",
                table: "Paquetes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Paquetes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GuiaColombia",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NombreImagen",
                table: "Paquetes",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TipoDeMercancia",
                table: "Paquetes",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ValorAPAgar",
                table: "Paquetes",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoMIA",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "EmpresaTransportadora",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "GuiaColombia",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "NombreImagen",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "TipoDeMercancia",
                table: "Paquetes");

            migrationBuilder.DropColumn(
                name: "ValorAPAgar",
                table: "Paquetes");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Paquetes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
