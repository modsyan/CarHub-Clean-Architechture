using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Mac.CarHub.Infrastructure.Data.Seeders;

public class CarSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // var logger = GetService<ILogger<CarSeeder>>();

        if (context.Cars.Any())
        {
            // logger.LogInformation("The database has already been seeded with cars.");
            return;
        }

        var cars = new List<Car>
        {
            new Car
            {
                ModelId = 1,
                ColorId = 1,
                EngineSerialNumber = "1234567890",
                Year = 2020,
                // Inspection = new Inspection(),
                // CarDocument = new CarDocument(),
                Created = DateTime.Now
            },
            new Car
            {
                ModelId = 2,
                ColorId = 2,
                EngineSerialNumber = "0987654321",
                Year = 2010,
                // Inspection = new Inspection(),
                // CarDocument = new CarDocument(),
                Created = DateTime.Now
            }
        };

        // can u write released cars and inspections and documents


        await context.Cars.AddRangeAsync(cars);
        await context.SaveChangesAsync();
    }
}
