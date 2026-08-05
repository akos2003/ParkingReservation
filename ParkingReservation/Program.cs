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

// AppDbContext regisztrációja a DI konténerben, beépített újrapróbálkozással (Docker miatt)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        connectionString,
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        });
});

WebApplication app = builder.Build();

// --- HTTP kérés folyamat (Pipeline) konfigurálása ---

// A Swaggert MINDIG engedélyezzük, hogy garantáltan elérjük a Dockerből is
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection(); // KIKOMMENTEZVE: Dockerben SSL tanúsítvány nélkül hibát okoz!

app.UseAuthorization();
app.MapControllers();

using (Microsoft.Extensions.DependencyInjection.IServiceScope scope = app.Services.CreateScope())
{
    ParkingReservation.Infrastructure.Data.AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<ParkingReservation.Infrastructure.Data.AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();

public partial class Program { }