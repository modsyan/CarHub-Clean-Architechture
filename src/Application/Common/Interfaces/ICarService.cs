using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface ICarService
{
    Task<bool> Exists(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Car>> GetCarsAsync(CancellationToken cancellationToken);


    Task<Car?> GetCarDetails(Guid id, CancellationToken cancellationToken, bool withNoTracking = false);

    Task<Car> CreateCarAsync(Car car, CancellationToken cancellationToken);
    Task<Car> UpdateCarAsync(Car car, CancellationToken cancellationToken);
    Task<Car> DeleteCarAsync(Guid id, CancellationToken cancellationToken);
}
