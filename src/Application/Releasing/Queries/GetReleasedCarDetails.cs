using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Releasing.Queries;

public record GetReleasedCarDetailsQuery(Guid CarId) : IRequest<ReleaseDto>
{
}

public class GetReleasedCarDetailsQueryValidator : AbstractValidator<GetReleasedCarDetailsQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetReleasedCarDetailsQueryValidator> _localizer;

    public GetReleasedCarDetailsQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetReleasedCarDetailsQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(r => r.CarId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(CarExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }

    private async Task<bool> CarExists(Guid carId, CancellationToken cancellationToken)
    {
        return await _context.Cars.AnyAsync(c => c.Id == carId, cancellationToken);
    }
}

public class GetReleasedCarDetailsQueryHandler : IRequestHandler<GetReleasedCarDetailsQuery, ReleaseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetReleasedCarDetailsQueryHandler> _localizer;
    private readonly IMapper _mapper;

    public GetReleasedCarDetailsQueryHandler(IApplicationDbContext context,
        IStringLocalizer<GetReleasedCarDetailsQueryHandler> localizer, IMapper mapper)
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }

    public async Task<ReleaseDto> Handle(GetReleasedCarDetailsQuery request, CancellationToken cancellationToken)
    {
        var release = await _context.Releases
                          .Include(r => r.Car).ThenInclude(c => c.Model).ThenInclude(m => m.Make)
                          .Include(r => r.Documents).ThenInclude(d => d.Image)
                          .Include(r => r.ReleaseRequests).ThenInclude(rr => rr.Documents).ThenInclude(d => d.Image)
                          .FirstOrDefaultAsync(r => r.CarId == request.CarId, cancellationToken)
                      ?? throw new NotFoundException(nameof(Release), request.CarId.ToString());

        return _mapper.Map<ReleaseDto>(release);
    }
}
