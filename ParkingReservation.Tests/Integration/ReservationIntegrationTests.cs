using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParkingReservation.Application.DTOs;
using ParkingReservation.Domain.Entities;
using ParkingReservation.Domain.Enums;
using ParkingReservation.Infrastructure.Data;
using Xunit;

namespace ParkingReservation.Tests.Integration;

public class ReservationIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ReservationIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CreateReservation_ValidRequest_ReturnsCreatedStatusCode()
    {
        // --- Arrange ---
        WebApplicationFactory<Program> customFactory = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Agresszív takarítás: Minden olyan regisztráció törlése, ami a DbContext-hez vagy az SQL kapcsolathoz kötődik
                System.Collections.Generic.List<ServiceDescriptor> descriptorsToRemove = System.Linq.Enumerable.ToList(
                    System.Linq.Enumerable.Where(services, d =>
                        d.ServiceType.Name.Contains("DbContextOptions") ||
                        d.ServiceType.Name.Contains("DbConnection")
                    )
                );

                foreach (ServiceDescriptor descriptor in descriptorsToRemove)
                {
                    services.Remove(descriptor);
                }

                // Tiszta InMemory adatbázis regisztrálása
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("IntegrationTestDb");
                });
            });
        });

        HttpClient client = customFactory.CreateClient();

        using (IServiceScope scope = customFactory.Services.CreateScope())
        {
            IServiceProvider scopedServices = scope.ServiceProvider;
            AppDbContext dbContext = scopedServices.GetRequiredService<AppDbContext>();

            // Tiszta lappal indítjuk az adatbázist
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            bool spaceExists = System.Linq.Enumerable.Any(dbContext.ParkingSpaces, p => p.Id == 1);
            if (!spaceExists)
            {
                ParkingSpace testSpace = new ParkingSpace
                {
                    Id = 1,
                    Type = ParkingSpaceType.Standard
                };

                dbContext.ParkingSpaces.Add(testSpace);
                dbContext.SaveChanges();
            }
        }

        CreateReservationDto newReservation = new CreateReservationDto
        {
            ParkingSpaceId = 1,
            ApplicantName = "Integrációs Tesztelő",
            StartTime = DateTimeOffset.UtcNow.AddDays(5),
            EndTime = DateTimeOffset.UtcNow.AddDays(5).AddHours(3),
            HasSpecialPermit = false,
            HasElectricVehicle = false
        };

        string jsonPayload = JsonSerializer.Serialize(newReservation);
        StringContent httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        // --- Act ---
        HttpResponseMessage response = await client.PostAsync("/api/reservations", httpContent);

        // --- Assert ---
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}