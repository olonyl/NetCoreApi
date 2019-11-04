using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamoLisbrosAPI.Migrations
{
    public partial class ModifiedFechaDevolucionDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDevolucion",
                table: "Prestamo",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDevolucion",
                table: "Prestamo",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
