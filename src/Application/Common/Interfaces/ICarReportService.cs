using Mac.CarHub.Application.Common.Models;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface ICarReportService
{
    Task<CarReportModel> GetCarReportAsync(CancellationToken cancellationToken);
}
