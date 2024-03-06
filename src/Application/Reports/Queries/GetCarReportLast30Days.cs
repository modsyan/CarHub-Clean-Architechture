using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;

namespace Mac.CarHub.Application.Reports.Queries;

public record GetCarReportLast30DaysQuery : IRequest<CarReportModel>;

public class GetCarReportLast30DaysQueryHandler(IApplicationDbContext context)
    : IRequestHandler<GetCarReportLast30DaysQuery, CarReportModel>
{
    public async Task<CarReportModel> Handle(GetCarReportLast30DaysQuery request, CancellationToken cancellationToken)
    {
        var enteredCars = await context.Cars
            .AsNoTracking()
            .Include(c => c.Model)
            .Include(c => c.Color)
            // .Include(c => c.Inspection)
            .Include(c => c.Release)
            .Where(c => c.Created >= DateTime.Now.AddDays(-30))
            .ToListAsync(cancellationToken);

        var overAllActives = await context.Events
            .AsNoTracking()
            .Where(e => e.Created >= DateTime.Now.AddDays(-30))
            .ToListAsync(cancellationToken);

        return new CarReportModel { EnteredCars = enteredCars, OverallActivities = overAllActives };
    }
}
