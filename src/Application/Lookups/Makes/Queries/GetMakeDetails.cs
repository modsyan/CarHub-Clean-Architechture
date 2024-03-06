using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Lookups.Makes.Queries;

public record GetMakerDetailQuery(int Id) : IRequest<MakeDto>;

public class GetMakerDetailQueryValidator : AbstractValidator<GetMakerDetailQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetMakerDetailQueryValidator> _localizer;

    public GetMakerDetailQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetMakerDetailQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(BeValidMakerId).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }


    private async Task<bool> BeValidMakerId(int id, CancellationToken cancellationToken)
    {
        return await _context.Makes.AnyAsync(v => v.Id == id, cancellationToken);
    }
}

public class GetMakerDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetMakerDetailQuery, MakeDto>
{
    public async Task<MakeDto> Handle(GetMakerDetailQuery request, CancellationToken cancellationToken)
    {
        var makeDto = await context.Makes
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Include(x => x.Models)
            .ProjectTo<MakeDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        return makeDto ?? throw new NotFoundException(nameof(Make), request.Id.ToString());
    }
}
