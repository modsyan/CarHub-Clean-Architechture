using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Mappings;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Documents.Queries;

public record GetDocumentTrashQuery : IRequest<PaginatedList<DocumentDto>>
{
    public Guid? CarId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    public string SortBy { get; init; } = "Created";
    public string SortOrder { get; init; } = "desc";
}

public class GetDocumentTrashQueryValidator : AbstractValidator<GetDocumentTrashQuery>
{
    private readonly ICarService _carService;
    private readonly IStringLocalizer<GetDocumentTrashQueryValidator> _localizer;

    public GetDocumentTrashQueryValidator(ICarService carService,
        IStringLocalizer<GetDocumentTrashQueryValidator> localizer)
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
            .GreaterThanOrEqualTo(1).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);
    }

    private async Task<bool> CarExists(Guid? id, CancellationToken cancellationToken)
    {
        return !id.HasValue || await _carService.Exists(id.Value, cancellationToken);
    }
}

public class GetDocumentTrashQueryHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<GetDocumentTrashQuery, PaginatedList<DocumentDto>>
{
    public async Task<PaginatedList<DocumentDto>> Handle(GetDocumentTrashQuery request,
        CancellationToken cancellationToken)
    {
        var query = context.Documents
            .IgnoreQueryFilters()
            .Where(d =>
                d.IsDeleted &&
                (request.CarId.HasValue ||
                 d.CarId == request.CarId))
            .AsNoTracking()
            .OrderByDescending(x => request.SortBy);

        if (request.SortOrder != "desc")
            query = query.OrderBy(x => request.SortBy);

        return await query
            .ProjectTo<DocumentDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
