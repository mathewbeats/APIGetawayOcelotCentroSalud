using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using APIGetaway;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");

// Configura Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API Gateway", Version = "v1" });

    // Define manualmente las operaciones API para reflejar las rutas de Ocelot
    c.DocumentFilter<SwaggerDocumentFilter>();
});

// Agrega Ocelot al contenedor de servicios
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

// Middleware para usar Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API Gateway V1");
});

// Configura el routing
app.UseRouting();

// Utiliza Ocelot en la aplicación
app.UseOcelot().Wait();

app.Run();
