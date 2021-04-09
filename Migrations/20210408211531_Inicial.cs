using Microsoft.EntityFrameworkCore.Migrations;

namespace TallerCuatro.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposMercancias",
                columns: table => new
                {
                    TipoMercanciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMercancias", x => x.TipoMercanciaId);
                });

            migrationBuilder.CreateTable(
                name: "Transportadoras",
                columns: table => new
                {
                    TransportadoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadoras", x => x.TransportadoraId);
                });

            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    PaqueteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMIA = table.Column<string>(nullable: true),
                    Peso = table.Column<double>(nullable: false),
                    NombreImagen = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    GuiaColombia = table.Column<int>(nullable: false),
                    ValorAPAgar = table.Column<float>(nullable: false),
                    TransportadoraId = table.Column<int>(nullable: false),
                    TipoMercanciaId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.PaqueteId);
                    table.ForeignKey(
                        name: "FK_Paquetes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquetes_TiposMercancias_TipoMercanciaId",
                        column: x => x.TipoMercanciaId,
                        principalTable: "TiposMercancias",
                        principalColumn: "TipoMercanciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paquetes_Transportadoras_TransportadoraId",
                        column: x => x.TransportadoraId,
                        principalTable: "Transportadoras",
                        principalColumn: "TransportadoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_ClienteId",
                table: "Paquetes",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_TipoMercanciaId",
                table: "Paquetes",
                column: "TipoMercanciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Paquetes_TransportadoraId",
                table: "Paquetes",
                column: "TransportadoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposMercancias");

            migrationBuilder.DropTable(
                name: "Transportadoras");
        }
    }
}
