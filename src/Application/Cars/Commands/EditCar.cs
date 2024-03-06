using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Domain.Enums;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Cars.Commands;

public record EditCarCommand : IRequest<CarDto>
{
    public Guid Id { get; set; }
    public string? EngineSerialNumber { get; set; } = String.Empty;
    public int? ModelId { get; set; }
    public int? Year { get; set; }
    public int? ColorId { get; set; }
}

public class EditCarCommandValidator : AbstractValidator<EditCarCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<EditCarCommandValidator> _localizer;

    public EditCarCommandValidator(IApplicationDbContext context, IStringLocalizer<EditCarCommandValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.EngineSerialNumber)
            .MaximumLength(200).WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_LENGTH, 200]);

        RuleFor(v => v.ModelId)
            .MustAsync(ModelExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        RuleFor(v => v.Year)
            .InclusiveBetween(1900, 2100).WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_YEAR]);

        RuleFor(v => v.ColorId)
            .MustAsync(BeColorExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }

    private async Task<bool> ModelExists(int? id, CancellationToken cancellationToken)
    {
        return !id.HasValue || await _context.Models.AnyAsync(m => m.Id == id, cancellationToken);
    }

    private async Task<bool> BeColorExists(int? id, CancellationToken cancellationToken)
    {
        return !id.HasValue || await _context.Colors.AnyAsync(c => c.Id == id, cancellationToken);
    }
}

public class EditCarCommandHandler(IApplicationDbContext context, IMapper mapper, ICarService carService)
    : IRequestHandler<EditCarCommand, CarDto>
{
    public async Task<CarDto> Handle(EditCarCommand request, CancellationToken cancellationToken)
    {
        var car = await carService.GetCarDetails(request.Id, cancellationToken) ??
                  throw new NotFoundException(nameof(Car), request.Id.ToString());

        if (request.EngineSerialNumber is not null)
            car.EngineSerialNumber = request.EngineSerialNumber;

        if (request.ModelId.HasValue)
            car.ModelId = request.ModelId.Value;

        if (request.Year.HasValue)
            car.Year = request.Year.Value;

        if (request.ColorId.HasValue)
            car.ColorId = request.ColorId.Value;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CarDto>(car);
    }
}
