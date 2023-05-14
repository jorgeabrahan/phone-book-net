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

app.Run();
