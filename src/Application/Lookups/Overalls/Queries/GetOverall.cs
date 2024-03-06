using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Lookups.Overalls.Queries;

public record GetOverallQuery : IRequest<OverallDto>;

public class GetOverallQueryHandler : IRequestHandler<GetOverallQuery, OverallDto>
{
    
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;

    public GetOverallQueryHandler(IApplicationDbContext context, IIdentityService identityService, IMapper mapper)
    {
        _context = context;
        _identityService = identityService;
        _mapper = mapper;
    }

    public async Task<OverallDto> Handle(GetOverallQuery request, CancellationToken cancellationToken)
    {
        var enteredCarsToday =
            await _context.Cars.CountAsync(c => c.Created > DateTime.Today, cancellationToken);

        var enteredCarsThisMonth =
            await _context.Cars.CountAsync(c => c.Created > DateTime.Today.AddDays(-30), cancellationToken);

        var enteredCarsThisYear =
            await _context.Cars.CountAsync(c => c.Created > DateTime.Today.AddDays(-365), cancellationToken);


        var totalCars = await _context.Cars.CountAsync(cancellationToken);

        var topBrokers = await _context.Brokers
            .Include(b => b.Cars)
            .OrderByDescending(b => b.Cars.Count)
            .Take(10)
            .ProjectTo<BrokerDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        foreach (var broker in topBrokers)
        {
            broker.UserDetails = await _identityService.GetUserDetailsAsync(broker.UserId);
        }

        var dto = new OverallDto
        {
            EnteredCarsToday = enteredCarsToday,
            EnteredCarsThisMonth = enteredCarsThisMonth,
            EnteredCarsThisYear = enteredCarsThisYear,
            TotalCars = totalCars,
            TopBrokers = topBrokers,
        };

        return dto;
    }
}
