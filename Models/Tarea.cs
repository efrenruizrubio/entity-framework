namespace projectef.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tarea
{
  // [Key]
  public Guid TareaId { get; set; }

  // [ForeignKey("CategoriaId")]
  public Guid CategoriaId { get; set; }

  // [Required]
  // [MaxLength(200)]
  public string Titulo { get; set; } = string.Empty;

  public string Descripcion { get; set; } = string.Empty;

  public Prioridad PrioridadTarea { get; set; }

  public DateTime FechaCreacion { get; set; }

  public virtual Categoria Categoria { get; set; } = null!;

  // [NotMapped]
  public string Resumen { get; set; } = string.Empty;

  public Boolean Completada { get; set; } = false;

}

public enum Prioridad
{
  Baja,
  Media,
  Alta
}