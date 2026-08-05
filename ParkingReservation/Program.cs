using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ParkingReservation.Infrastructure.Data;
using ParkingReservation.Application.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// --- Szolgáltatások (Services) regisztrációja ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IParkingSpaceService, ParkingSpaceService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

// Csatlakozási karakterlánc beolvasása biztonságosan
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("A 'DefaultConnection' connection string nem található az appsettings.json fájlban.");

// AppDbContext regisztrációja a DI konténerben
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

WebApplication app = builder.Build();

// --- HTTP kérés folyamat (Pipeline) konfigurálása ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();