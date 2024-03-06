using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.UpcomingEvents.Queries.GetUpcomingEventDetails;

public record GetUpcomingEventDetailsQuery(DateTime date) : IRequest<UpcomingEventVm>
{
}

public class GetUpcomingEventDetailsQueryValidator : AbstractValidator<GetUpcomingEventDetailsQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetUpcomingEventDetailsQueryValidator> _localizer;

    public GetUpcomingEventDetailsQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetUpcomingEventDetailsQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(r => r.date)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class GetUpcomingEventDetailsQueryHandler : IRequestHandler<GetUpcomingEventDetailsQuery, UpcomingEventVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUpcomingEventDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UpcomingEventVm> Handle(GetUpcomingEventDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var upcomingEventAtThatDayFromCars = await _context.Cars
            .Include(c => c.Release)
            .Include(car => car.Model).ThenInclude(model => model.Make)
            .Where(c => (c.Release != null && c.Release.ReleaseDate.Date == request.date.Date))
            .ProjectTo<UpcomingEventDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new UpcomingEventVm
        {
            UpcomingEvents = upcomingEventAtThatDayFromCars
        };
    }
}
