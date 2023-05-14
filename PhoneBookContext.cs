using agenda.Models;
using Microsoft.EntityFrameworkCore;

namespace agenda;

public class PhoneBookContext : DbContext
{
  public DbSet<CodigoArea>? CodigoAreas { get; set; }
  public DbSet<Telefono>? Telefonos { get; set; }
  public DbSet<Persona>? Personas { get; set; }

  public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options) { }
}
