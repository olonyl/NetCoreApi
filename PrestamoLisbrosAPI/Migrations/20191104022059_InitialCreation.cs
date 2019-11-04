using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamoLisbrosAPI.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Nacionalidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    IdLector = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CI = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Dierccion = table.Column<string>(nullable: true),
                    Carrera = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.IdLector);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Editorial = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                });

            migrationBuilder.CreateTable(
                name: "LibAut",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibAut", x => new { x.IdAutor, x.IdLibro });
                    table.ForeignKey(
                        name: "FK_LibAut_Autor_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibAut_Libro_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    IdLector = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false),
                    FechaPrestamo = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaDevolucion = table.Column<DateTime>(nullable: false),
                    Devuelto = table.Column<bool>(nullable: false,defaultValue:false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => new { x.IdLector, x.IdLibro, x.FechaPrestamo });
                    table.ForeignKey(
                        name: "FK_Prestamo_Estudiante_IdLector",
                        column: x => x.IdLector,
                        principalTable: "Estudiante",
                        principalColumn: "IdLector",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamo_Libro_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libro",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibAut_IdLibro",
                table: "LibAut",
                column: "IdLibro");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_IdLibro",
                table: "Prestamo",
                column: "IdLibro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibAut");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Libro");
        }
    }
}
