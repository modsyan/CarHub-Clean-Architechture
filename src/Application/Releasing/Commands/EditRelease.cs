using Mac.CarHub.Application.Common.Exceptions;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Releasing.Commands;

public record EditReleaseCommand : IRequest<ReleaseDto>
{
    public Guid CarId { get; set; }
}

public class EditReleaseCommandValidator : AbstractValidator<EditReleaseCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<EditReleaseCommandValidator> _localizer;

    public EditReleaseCommandValidator(IApplicationDbContext context,
        IStringLocalizer<EditReleaseCommandValidator> localizer)
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

public class EditReleaseCommandHandler : IRequestHandler<EditReleaseCommand, ReleaseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ICarService _carService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<EditReleaseCommandHandler> _localizer;


    public EditReleaseCommandHandler(IApplicationDbContext context, ICarService carService, IMapper mapper,
        IStringLocalizer<EditReleaseCommandHandler> localizer)
    {
        _context = context;
        _carService = carService;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<ReleaseDto> Handle(EditReleaseCommand request, CancellationToken cancellationToken)
    {
        var car = await _context.Cars
            .Include(c => c.Release)
            .FirstOrDefaultAsync(c => c.Id == request.CarId, cancellationToken)
                  ?? throw new NotFoundException(nameof(Car), request.CarId.ToString());

        if (car.Release == null)
            throw new BadRequestException(_localizer[SharedResourcesKeys.ERR_RELEASE_NOT_FOUND]);

        car.Release = null;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ReleaseDto>(car.Release);
    }
}
