namespace agenda.Models;

public class CodigoArea
{
  public Guid CodigoAreaId { get; set; }
  public int Numero { get; set; }
  public string Pais { get; set; } = "";

  public virtual ICollection<Telefono>? Telefonos { get; set; }
}
