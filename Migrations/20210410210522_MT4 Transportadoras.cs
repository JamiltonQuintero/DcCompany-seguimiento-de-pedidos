using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerCuatro.Migrations
{
    public partial class MT4Transportadoras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Transportadoras",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CiudadSede",
                table: "Transportadoras",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Transportadoras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rut",
                table: "Transportadoras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Telefono",
                table: "Transportadoras",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CiudadSede",
                table: "Transportadoras");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Transportadoras");

            migrationBuilder.DropColumn(
                name: "Rut",
                table: "Transportadoras");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Transportadoras");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Transportadoras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
