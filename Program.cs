/*
 *
 * Tuve un problema ejecutanto el programa:
 * > dotnet run
 * Compilando...
 * You must install or update .NET to run this application.

 * App: /home/lauta/dev/csharp/PizzaStore/bin/Debug/net8.0/PizzaStore
 * Architecture: x64
 * Framework: 'Microsoft.AspNetCore.App', version '8.0.0' (x64)
 * .NET location: /usr/share/dotnet

 * No frameworks were found.

 * Learn more:
 * https://aka.ms/dotnet/app-launch-failed

 * To install missing framework, download:
 https://aka.ms/dotnet-core-applaunch?framework=Microsoft.AspNetCore.App&framework_version=8.0
.0&arch=x64&rid=arch-x64&os=manjaro
 *
 * Lo solucione intalando: aspnet-runtime
 * sudo pacman -S aspnet-runtime
 * 
 * De este repo lo saque: https://github.com/dotnet/core/issues/7087
 * */

using PizzaStore.DB;

var builder = WebApplication.CreateBuilder(args);


// `builder` tiene la propiedad service que se puede agregar caracteristicas
// Se configura la funcionalidades que tendra la API
builder.Services.AddCors(ops => {}); // Añadir cors

// Expecificar el puerto
builder.WebHost.ConfigureKestrel(opts => 
{
  opts.ListenAnyIP(5000);
});

builder.Services.AddEndpointsApiExplorer();

// Aquí se usa
var app = builder.Build();

app.MapGet("/", () => {
  return PizzaDb.GetPizzas();
});

app.MapGet("/{id}", (int id) =>
{
  return PizzaDb.GetPizzas(id);
});

app.MapPost("/add",(Pizza pizza) =>
{
  return PizzaDb.AddGame(pizza.Title);
});

app.MapPut("/update", (Pizza pizza) =>
{
  return PizzaDb.UpdateGame(pizza);
});

app.MapDelete("/del", (int id) =>
{
  System.Console.WriteLine(id);
  return PizzaDb.DeleteGame(id);
});

app.MapGet("/papu", () => "papu");

app.Run();


