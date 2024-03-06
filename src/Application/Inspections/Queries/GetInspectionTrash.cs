using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Mappings;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Queries;

public record GetInspectionTrashQuery : IRequest<PaginatedList<InspectionDto>>
{
    public Guid? CarId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string SortBy { get; init; } = "Created";
    public string SortOrder { get; init; } = "desc";
}

public class GetInspectionTrashQueryValidator : AbstractValidator<GetInspectionTrashQuery>
{
    private readonly ICarService _carService;
    private readonly IStringLocalizer<GetInspectionTrashQueryValidator> _localizer;

    public GetInspectionTrashQueryValidator(ICarService carService,
        IStringLocalizer<GetInspectionTrashQueryValidator> localizer)
    {
        _carService = carService;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.CarId)
            .MustAsync(CarExists)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);
    }

    private async Task<bool> CarExists(Guid? id, CancellationToken cancellationToken)
    {
        return !id.HasValue || await _carService.Exists(id.Value, cancellationToken);
    }
}

public class GetInspectionTrashQueryHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<GetInspectionTrashQuery, PaginatedList<InspectionDto>>
{
    public async Task<PaginatedList<InspectionDto>> Handle(GetInspectionTrashQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Inspections
            .IgnoreQueryFilters()
            .Where(d => d.IsDeleted && (!request.CarId.HasValue || d.CarId == request.CarId))
            .AsNoTracking()
            .OrderByDescending(x => request.SortBy);

        if (request.SortOrder != "desc")
            query = query.OrderBy(x => request.SortBy);

        return await query
            .ProjectTo<InspectionDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
