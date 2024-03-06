#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;

namespace Mac.CarHub.Infrastructure.Services.Cars;

public class CarService(ApplicationDbContext context) : ICarService
{
    public async Task<bool> Exists(Guid id, CancellationToken cancellationToken)
    {
        return context.Cars.Any(x => x.Id == id);
    }

    public async Task<IEnumerable<Car>> GetCarsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Car?> GetCarDetails(
        Guid id,
        CancellationToken cancellationToken,
        bool withNoTracking = false
    )
    {
        var query = context.Cars
            .Where(x => x.Id == id)
            .Include(c => c.Model).ThenInclude(m => m.Make)
            .Include(c => c.Inspections).ThenInclude(i => i.File)
            .Include(c => c.Documents).ThenInclude(i => i.File)
            .Include(c => c.Release)
            .Include(c => c.Color)
            .AsQueryable();

        if (withNoTracking) query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(cancellationToken);
    }


    public async Task<Car> CreateCarAsync(Car car, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Car> UpdateCarAsync(Car car, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Car> DeleteCarAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
