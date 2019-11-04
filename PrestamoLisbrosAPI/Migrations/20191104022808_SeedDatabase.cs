using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamoLisbrosAPI.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "IdAutor", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { 1, "USA", "Mario Benedetti" },
                    { 2, "Francia", "Justino Aragon" },
                    { 3, "USA", "Jefferson Jhonson" }
                });

            migrationBuilder.InsertData(
                table: "Estudiante",
                columns: new[] { "IdLector", "CI", "Carrera", "Dierccion", "Edad", "Nombre" },
                values: new object[,]
                {
                    { 1, "294568", "Informática", "Calle Masaya Residencial Mayales Casa B-22", 19, "Felipe Loayza Beramendi" },
                    { 2, "294568", "Informática", "Calle Masaya Residencial Mayales Casa B-22", 20, "Daniel Gonzales" },
                    { 3, "897867", "Quimica", "Calle Granada Residencial Mayales Casa B-92", 18, "Josefina Gomez" }
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "IdLibro", "Area", "Editorial", "Titulo" },
                values: new object[,]
                {
                    { 1, "Internet", "Alfa", "Visual Studio Net" },
                    { 2, "Base de Datos", "Omega", "Base de Datos" },
                    { 3, "Internet", "Alfa", "Hacking" }
                });

            migrationBuilder.InsertData(
                table: "LibAut",
                columns: new[] { "IdAutor", "IdLibro" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Prestamo",
                columns: new[] { "IdLector", "IdLibro", "FechaPrestamo", "Devuelto", "FechaDevolucion" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2007, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2007, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 1, new DateTime(2007, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2007, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2007, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2007, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2007, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2007, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autor",
                keyColumn: "IdAutor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LibAut",
                keyColumns: new[] { "IdAutor", "IdLibro" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "LibAut",
                keyColumns: new[] { "IdAutor", "IdLibro" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "LibAut",
                keyColumns: new[] { "IdAutor", "IdLibro" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Prestamo",
                keyColumns: new[] { "IdLector", "IdLibro", "FechaPrestamo" },
                keyValues: new object[] { 1, 1, new DateTime(2007, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Prestamo",
                keyColumns: new[] { "IdLector", "IdLibro", "FechaPrestamo" },
                keyValues: new object[] { 1, 1, new DateTime(2007, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Prestamo",
                keyColumns: new[] { "IdLector", "IdLibro", "FechaPrestamo" },
                keyValues: new object[] { 2, 2, new DateTime(2007, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Prestamo",
                keyColumns: new[] { "IdLector", "IdLibro", "FechaPrestamo" },
                keyValues: new object[] { 3, 2, new DateTime(2007, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                table: "Autor",
                keyColumn: "IdAutor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Autor",
                keyColumn: "IdAutor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estudiante",
                keyColumn: "IdLector",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estudiante",
                keyColumn: "IdLector",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estudiante",
                keyColumn: "IdLector",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Libro",
                keyColumn: "IdLibro",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Libro",
                keyColumn: "IdLibro",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Libro",
                keyColumn: "IdLibro",
                keyValue: 3);
        }
    }
}
