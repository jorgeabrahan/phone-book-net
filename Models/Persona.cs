using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace agenda.Models;

public class Persona
{
  [Key]
  public Guid PersonaId { get; set; }

  [Required]
  [MaxLength(250)]
  public string? Nombre { get; set; }

  [Required]
  [MaxLength(250)]
  public string? Apellido { get; set; }

  [MaxLength(100)]
  public string? Alias { get; set; }
  public DateOnly FechaNacimiento { get; set; }

  [NotMapped]
  public int Edad { get; set; }

  public Sexos Sexo { get; set; }
  public EstadosCiviles EstadoCivil { get; set; }
  public string? Correo { get; set; }

  public virtual ICollection<Telefono>? Telefonos { get; set; }
}

public enum Sexos
{
  Masculino,
  Femenino,
  Otro
}

public enum EstadosCiviles
{
  Soltero,
  Casado,
  UnionLibre,
  Viudo,
  Divorciado
}