using System.Linq.Expressions;
using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Domain.Enums;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.UpcomingEvents.Queries;

public record GetUpcomingEventsQuery : IRequest<UpcomingEventVm>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortOrder { get; set; } = "asc";
    public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-30);
    public DateTime EndDate { get; set; } = DateTime.Now;
}

public class GetUpcomingEventsQueryValidator : AbstractValidator<GetUpcomingEventsQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetUpcomingEventsQueryValidator> _localizer;

    public GetUpcomingEventsQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetUpcomingEventsQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        // RuleFor(r => r.PageNumber)
        //     .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);
        //
        // RuleFor(r => r.PageSize)
        //     .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);

        RuleFor(r => r.SortOrder)
            .Must(s => s is "asc" or "desc").WithMessage(_localizer[SharedResourcesKeys.ERR_SORT_ORDER]);
        
        RuleFor(r => r.StartDate)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
        
        RuleFor(r => r.EndDate)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUpcomingEventsQuery, UpcomingEventVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUpcomingEventsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UpcomingEventVm> Handle(GetUpcomingEventsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Cars
            .Include(c => c.Release)
            .Include(car => car.Model).ThenInclude(model => model.Make)
            .Include(c => c.Color)
            .Include(c => c.ParkingSlot)
            .AsQueryable();

        query = query.Where(c => (
            c.Release != null &&
            c.Release.ReleaseDate >= request.StartDate &&
            c.Release.ReleaseDate <= request.EndDate
        ));

        query = request.SortOrder switch
        {
            "asc" => query.OrderBy(c => c.Release!.ReleaseDate),
            "desc" => query.OrderByDescending(c => c.Release!.ReleaseDate),
            _ => query.OrderBy(c => c.Release!.ReleaseDate)
        };

        var upcomingEventList = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<UpcomingEventDto>(_mapper.ConfigurationProvider)
            // .Select(c => new UpcomingEventDto
            // {
            //     Car = _mapper.ProjectTo<CarBriefDto>(c).FirstOrDefault(),
            //     Date = c.Release!.ReleaseDate,
            //     Type = c.Release.ReleaseDate > DateTime.Now
            //         ? EventType.Release.GetDisplayName()
            //         : EventType.Other.GetDisplayName()
            // })
            .ToListAsync(cancellationToken);

        return new UpcomingEventVm { UpcomingEvents = upcomingEventList };
    }
}
