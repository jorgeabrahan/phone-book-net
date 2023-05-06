namespace agenda.Models;

public class Persona
{
  public Guid PersonaId { get; set; }
  public string? Nombre { get; set; }
  public string? Apellido { get; set; }
  public string? Alias { get; set; }
  public DateOnly FechaNacimiento { get; set; }
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