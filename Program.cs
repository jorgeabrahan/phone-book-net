using agenda.Models;
using agenda;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<PhoneBookContext>("Data Source=localhost;Initial Catalog=AgendaDB;user id=sa;password=C0ntrol1*;Encrypt=False");
var app = builder.Build();

app.MapGet("/", () => "Phone Book HomePage");
// endpoint to validate connection!
app.MapGet("/connect", ([FromServices] PhoneBookContext context) =>
{
  context.Database.EnsureCreated();
  return Results.Ok("Base de datos en linea!");
});

/* GET ENDPOINTS */

// endpoint to get all persons
app.MapGet("/api/personas", ([FromServices] PhoneBookContext context) =>
{
  return Results.Ok(context.Personas);
});

// endpoint to get all area codes
app.MapGet("/api/codigosarea", ([FromServices] PhoneBookContext context) =>
{
  return Results.Ok(context.CodigoAreas);
});

// endpoint to get all phones
app.MapGet("/api/telefonos", ([FromServices] PhoneBookContext context) =>
{
  return Results.Ok(context.Telefonos);
});

/* POST ENDPOINTS */

// enpoint to post a person
app.MapPost("/api/persona", async ([FromServices] PhoneBookContext context, [FromBody] Persona persona) =>
{
  persona.PersonaId = Guid.NewGuid();
  await context.AddAsync(persona);
  await context.SaveChangesAsync();
  return Results.Ok(persona.PersonaId);
});

// endpoint to post an area code
app.MapPost("/api/codigoarea", async ([FromServices] PhoneBookContext context, [FromBody] CodigoArea codigoArea) =>
{
  codigoArea.CodigoAreaId = Guid.NewGuid();
  await context.AddAsync(codigoArea);
  await context.SaveChangesAsync();
  return Results.Ok(codigoArea.CodigoAreaId);
});

// endpoint to post a phone
app.MapPost("/api/telefono", async ([FromServices] PhoneBookContext context, [FromBody] Telefono telefono) =>
{
  telefono.TelefonoId = Guid.NewGuid();
  await context.AddAsync(telefono);
  await context.SaveChangesAsync();
  return Results.Ok(telefono.TelefonoId);
});

app.Run();
