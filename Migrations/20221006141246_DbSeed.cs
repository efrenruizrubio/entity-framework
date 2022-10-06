using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class DbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("2165a639-3484-4e3b-9606-953d68d2ba0f"), "", "Actividades personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("2165a639-3484-4e3b-9606-953d68d2ba59"), "", "Actividades pendientes", 20 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("a5b0b2a1-3b1f-4b9f-8b1a-1c5b2b2b2b2b"), "", "Actividades pendientes", 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2165a639-3484-4e3b-9606-953d68d2ba0f"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2165a639-3484-4e3b-9606-953d68d2ba59"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a5b0b2a1-3b1f-4b9f-8b1a-1c5b2b2b2b2b"));
        }
    }
}
