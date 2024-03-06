using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Lookups.Makes.Queries;

public record GetMakesQuery : IRequest<MakeVm>
{
    public int? PageNumber { get; set; } = 1;
    public int? PageSize { get; set; } = 10;
    public string? SearchString { get; set; } = "";
}

public class GetMakesQueryValidator : AbstractValidator<GetMakesQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetMakesQueryValidator> _localizer;

    public GetMakesQueryValidator(IApplicationDbContext context, IStringLocalizer<GetMakesQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.PageNumber)
            // .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_OUT_OF_RANGE]);

        RuleFor(v => v.PageSize)
            // .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_OUT_OF_RANGE]);

        // RuleFor(v => v.SearchString)
        //     .MaximumLength(50).WithMessage(_localizer[SharedResourcesKeys.ERR_REGEX_COMMON_INPUT_MAX_LENGTH]);
    }
}

public class GetMakesQueryHandler : IRequestHandler<GetMakesQuery, MakeVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetMakesQueryHandler> _localizer;

    public GetMakesQueryHandler(IApplicationDbContext context, IMapper mapper,
        IStringLocalizer<GetMakesQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<MakeVm> Handle(GetMakesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Makes
            .AsNoTracking()
            .Include(m => m.Models)
            .Where(x => string.IsNullOrEmpty(request.SearchString) || x.Name.Contains(request.SearchString));

        if (request is { PageSize: not null })
            query = query.Take(request.PageSize.Value);

        if (request is { PageSize: not null, PageNumber: not null })
            query = query.Skip((request.PageNumber.Value - 1) * request.PageSize.Value);

        var makes = await query
            .OrderBy(x => x.Name)
            .ProjectTo<MakeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var makeVm = new MakeVm() { Makes = makes, TotalCount = await _context.Makes.CountAsync(cancellationToken) };

        return makeVm;
    }
}
