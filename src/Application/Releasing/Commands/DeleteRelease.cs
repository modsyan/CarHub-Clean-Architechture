using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Releasing.Commands;

public record DeleteReleaseCommand(Guid CarId) : IRequest<ReleaseDto>
{
}

public class DeleteReleaseCommandValidator : AbstractValidator<DeleteReleaseCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<DeleteReleaseCommandValidator> _localizer;

    public DeleteReleaseCommandValidator(IApplicationDbContext context,
        IStringLocalizer<DeleteReleaseCommandValidator> localizer)
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

        RuleFor(r => r.CarId)
            .MustAsync(ReleaseExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }

    private async Task<bool> CarExists(Guid carId, CancellationToken cancellationToken)
    {
        return await _context.Cars.AnyAsync(c => c.Id == carId, cancellationToken);
    }

    private async Task<bool> ReleaseExists(Guid carId, CancellationToken cancellationToken)
    {
        return await _context.Releases.AnyAsync(r => r.CarId == carId, cancellationToken);
    }
}

public class DeleteReleaseCommandHandler : IRequestHandler<DeleteReleaseCommand, ReleaseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<DeleteReleaseCommandHandler> _localizer;
    private readonly IMapper _mapper;

    public DeleteReleaseCommandHandler(IApplicationDbContext context,
        IStringLocalizer<DeleteReleaseCommandHandler> localizer, IMapper mapper)
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }

    public async Task<ReleaseDto> Handle(DeleteReleaseCommand request, CancellationToken cancellationToken)
    {
        var release = await _context.Releases
                          .Include(c => c.Car).ThenInclude(c => c.Model).ThenInclude(m => m.Make)
                          .FirstOrDefaultAsync(r => r.CarId == request.CarId, cancellationToken)
                      ?? throw new NotFoundException(nameof(Release), request.CarId.ToString());

        _context.Releases.Remove(release);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ReleaseDto>(release);
    }
}
