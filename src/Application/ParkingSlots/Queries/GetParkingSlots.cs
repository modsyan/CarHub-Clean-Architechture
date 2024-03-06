using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Mappings;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.ParkingSlots.Queries;

public record GetParkingSlotsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PaginatedList<ParkingSlotDto>>;

public class GetParkingSlotsQueryValidator : AbstractValidator<GetParkingSlotsQuery>
{
    private readonly IStringLocalizer<GetParkingSlotsQueryValidator> _localizer;

    public GetParkingSlotsQueryValidator(IStringLocalizer<GetParkingSlotsQueryValidator> localizer)
    {
        _localizer = localizer;
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        // RuleFor(x => x.PageNumber)
        //     .GreaterThanOrEqualTo(1).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);
        //
        // RuleFor(x => x.PageSize)
        //     .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);
    }
}

public class GetParkingSlotsQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetParkingSlotsQuery, PaginatedList<ParkingSlotDto>>
{
    public async Task<PaginatedList<ParkingSlotDto>> Handle(GetParkingSlotsQuery request,
        CancellationToken cancellationToken)
    {
        var parkingSlots = await context.ParkingSlots
            .Include(x => x.Cars).ThenInclude(x => x.Model).ThenInclude(x => x.Make)
            .OrderBy(x => x.Title)
            .ProjectTo<ParkingSlotDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return parkingSlots;
    }
}
