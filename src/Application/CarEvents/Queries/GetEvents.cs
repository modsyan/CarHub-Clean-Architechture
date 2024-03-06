using System.Linq.Expressions;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.CarEvents.Queries;

public record GetCarEventsQuery : IRequest<EventVm>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string SortBy { get; init; } = "Date";
    public string SortOrder { get; init; } = "asc";
    public string SearchString { get; init; } = "";
}

public class GetCarEventsQueryValidator : AbstractValidator<GetCarEventsQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetCarEventsQueryValidator> _localizer;


    public GetCarEventsQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetCarEventsQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.PageNumber)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);

        RuleFor(v => v.PageSize)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);

        RuleFor(v => v.SortBy)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(v => v.SortOrder)
            // .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            // .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
            .Must(x => x is "asc" or "desc").WithMessage(_localizer[SharedResourcesKeys.ERR_SORT_ORDER])
            ;

        RuleFor(v => v.SearchString)
            // .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            // .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
            ;
    }
}

public class GetCarEventsQueryHandler : IRequestHandler<GetCarEventsQuery, EventVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetCarEventsQueryHandler> _localizer;


    public GetCarEventsQueryHandler(IApplicationDbContext context, IMapper mapper,
        IStringLocalizer<GetCarEventsQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<EventVm> Handle(GetCarEventsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Event, object>> orderBy = request.SortBy switch
        {
            "Date" => x => x.Created,
            "date" => x => x.Created,
            "Type" => x => x.EventType,
            "EventType" => x => x.EventType,
            _ => x => x.Created
        };

        var query = _context.Events
            .AsNoTracking()
            .AsQueryable();

        query = request.SortOrder switch
        {
            "asc" => query.OrderBy(orderBy),
            "desc" => query.OrderByDescending(orderBy),
            _ => query.OrderBy(orderBy)
        };

        // Expression<Func<Event, bool>> filter = request.SearchString switch
        // {
        //     // "" => x => true,
        //     // _ => x => x.EventType
        //     //               (request.SearchString) ||
        //     //         x.EventDescription.Contains(request.SearchString)
        // };

        // if (!string.IsNullOrWhiteSpace(request.SearchString))
        // {
        //     // query = query.Where(x => x.EventType.Contains(request.SearchString));
        // }

        var events = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
            ;

        var totalItems = await _context.Events.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling(totalItems / (double)request.PageSize);

        return new EventVm
        {
            Events = events,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }
}
