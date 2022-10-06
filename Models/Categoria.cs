namespace projectef.Models;

using System.ComponentModel.DataAnnotations;

public class Categoria
{
  // [Key]
  public Guid CategoriaId { get; set; }

  // [Required]
  // [MaxLength(150)]
  public string Nombre { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;

  public int Peso { get; set; }
  public virtual ICollection<Tarea> Tareas { get; set; } = null!;

}