using projectef;
using projectef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", ([FromServicesAttribute] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos creada en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.Tareas.Include(p => p.Categoria)/* .Where(p => p.Completada == false) */);
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
  tarea.TareaId = Guid.NewGuid();
  tarea.FechaCreacion = DateTime.Now;

  await dbContext.AddAsync(tarea);
  // await dbContext.Tareas.AddAsync(tarea);
  await dbContext.SaveChangesAsync();

  return Results.Ok("Tarea creada");
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{

  Tarea? tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual != null)
  {
    tareaActual.CategoriaId = tarea.CategoriaId;
    tareaActual.Titulo = tarea.Titulo;
    tareaActual.PrioridadTarea = tarea.PrioridadTarea;
    tareaActual.Descripcion = tarea.Descripcion;
    tareaActual.Completada = tarea.Completada;

    await dbContext.SaveChangesAsync();

    return Results.Ok("Tarea actualizada");

  }
  return Results.NotFound("Tarea a actualizar no encontrada");
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
  Tarea? tareaActual = dbContext.Tareas.Find(id);

  if (tareaActual != null)
  {
    dbContext.Remove(tareaActual);
    await dbContext.SaveChangesAsync();

    return Results.Ok("Tarea eliminada");
  }
  return Results.NotFound("Tarea a eliminar no encontrada");
});

app.Run();
