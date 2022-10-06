using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectef.Migrations
{
    public partial class NewDbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2165a639-3484-4e3b-9606-953d68d2ba0f"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("a5b0b2a1-3b1f-4b9f-8b1a-1c5b2b2b2b2b"));

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Completada", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("9169308d-e5cd-412c-a50f-ba4bc501cabb"), new Guid("2165a639-3484-4e3b-9606-953d68d2ba59"), false, "Descripción de la tarea 1", new DateTime(2022, 10, 6, 9, 38, 26, 106, DateTimeKind.Local).AddTicks(7923), 1, "Tarea 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9169308d-e5cd-412c-a50f-ba4bc501cabb"));

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("2165a639-3484-4e3b-9606-953d68d2ba0f"), "", "Actividades personales", 50 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("a5b0b2a1-3b1f-4b9f-8b1a-1c5b2b2b2b2b"), "", "Actividades pendientes", 20 });
        }
    }
}
