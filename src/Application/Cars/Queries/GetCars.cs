using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Mappings;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Cars.Queries;

public record GetCarsQuery : IRequest<CarVm>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SearchString { get; set; } = string.Empty;
}

public class GetCarsQueryValidator : AbstractValidator<GetCarsQuery>
{
    private IApplicationDbContext _context;
    private IStringLocalizer<GetCarsQueryValidator> _localizer;

    public GetCarsQueryValidator(IApplicationDbContext context, IStringLocalizer<GetCarsQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        // RuleFor(v => v.PageNumber)
        // .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
        // .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
        // .GreaterThanOrEqualTo(1).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);

        // RuleFor(v => v.PageSize)
        // .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
        // .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
        // .GreaterThanOrEqualTo(1).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);
    }
}

public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, CarVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetCarsQueryHandler> _localizer;


    public GetCarsQueryHandler(IApplicationDbContext context,
        IStringLocalizer<GetCarsQueryHandler> localizer,
        IMapper mapper)
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }

    public async Task<CarVm> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Cars
            .Include(c => c.Model).ThenInclude(c => c.Make)
            .Include(c => c.Color)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchString))
        {
            query = query
                .Where(c =>
                    c.Model.Name.Contains(request.SearchString) ||
                    c.Color.ArName.Contains(request.SearchString) ||
                    c.Color.EnName.Contains(request.SearchString) ||
                    c.Model.Make.Name.Contains(request.SearchString)
                );
        }

        var result = await query
            .OrderBy(c => c.Id)
            .ProjectTo<CarBriefDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        int totalCount = await query.CountAsync(cancellationToken);

         var carVm = new CarVm
        {
            Cars = result,
            CurrentPage = request.PageSize,
            PageSize = request.PageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize)
        };

        return carVm;
    }
}
