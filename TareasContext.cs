namespace projectef;
using Microsoft.EntityFrameworkCore;
using projectef.Models;

public class TareasContext : DbContext
{
  public DbSet<Categoria> Categorias { get; set; }
  public DbSet<Tarea> Tareas { get; set; }
  public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Categoria> categoriasInit = new List<Categoria>();
    categoriasInit.Add(new Categoria()
    {
      CategoriaId = Guid.Parse("2165a639-3484-4e3b-9606-953d68d2ba59"),
      Nombre = "Actividades pendientes",
      Peso = 20
    });
    categoriasInit.Add(new Categoria()
    {
      CategoriaId = Guid.Parse("a5b0b2a1-3b1f-4b9f-8b1a-1c5b2b2b2b2b"),
      Nombre = "Actividades pendientes",
      Peso = 20
    });
    categoriasInit.Add(new Categoria()
    {
      CategoriaId = Guid.Parse("2165a639-3484-4e3b-9606-953d68d2ba0f"),
      Nombre = "Actividades personales",
      Peso = 50
    });

    modelBuilder.Entity<Categoria>(categoria =>
    {
      categoria.ToTable("Categoria");
      categoria.HasKey(p => p.CategoriaId);
      categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
      categoria.Property(p => p.Descripcion);
      categoria.Property(p => p.Peso);
      categoria.HasData(categoriasInit);
    });

    List<Tarea> tareasInit = new List<Tarea>();
    tareasInit.Add(new Tarea()
    {
      TareaId = Guid.Parse("2165a520-3484-4e3b-9606-953d68d2ba59"),
      CategoriaId = Guid.Parse("2165a639-3484-4e3b-9606-953d68d2ba59"),
      PrioridadTarea = Prioridad.Media,
      Titulo = "Tarea 1",
      FechaCreacion = DateTime.Now,
      Descripcion = "Descripción de la tarea 1",
      Completada = false
    });
    tareasInit.Add(new Tarea()
    {
      TareaId = Guid.Parse("2165a777-3484-4e3b-9606-953d68d2ba59"),
      CategoriaId = Guid.Parse("a5b0b2a1-3b1f-4b9f-8b1a-1c5b2b2b2b2b"),
      PrioridadTarea = Prioridad.Baja,
      Titulo = "Tarea 2",
      FechaCreacion = DateTime.Now,
      Descripcion = "Descripción de la tarea 2",
      Completada = false
    });
    tareasInit.Add(new Tarea()
    {
      TareaId = Guid.Parse("2165affa-3484-4e3b-9606-953d68d2ba59"),
      CategoriaId = Guid.Parse("2165a639-3484-4e3b-9606-953d68d2ba0f"),
      PrioridadTarea = Prioridad.Alta,
      Titulo = "Tarea 3",
      FechaCreacion = DateTime.Now,
      Descripcion = "Descripción de la tarea 3",
      Completada = false
    });


    modelBuilder.Entity<Tarea>(tarea =>
    {
      tarea.ToTable("Tarea");
      tarea.HasKey(p => p.TareaId);
      tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
      tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
      tarea.Property(p => p.Descripcion);
      tarea.Property(p => p.PrioridadTarea);
      tarea.Property(p => p.FechaCreacion);
      tarea.Property(p => p.Completada);
      tarea.HasData(tareasInit);
      tarea.Ignore(p => p.Resumen);
    });
  }
}