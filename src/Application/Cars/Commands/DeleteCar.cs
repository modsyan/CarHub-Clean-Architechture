using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Cars.Commands;

public record DeleteCarCommand(Guid Id) : IRequest<CarDto>;

public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<DeleteCarCommandValidator> _localizer;

    public DeleteCarCommandValidator(IApplicationDbContext context,
        IStringLocalizer<DeleteCarCommandValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
        ApplyCustomValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }

    private async Task<bool> IsCarExists(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Cars.AnyAsync(l => l.Id == id, cancellationToken);
    }

    private void ApplyCustomValidationRules()
    {
        RuleFor(x => x.Id)
            .MustAsync(IsCarExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }
}

public class DeleteCarCommandHandler(
    ICarService carService,
    IMapper mapper,
    IStringLocalizer<DeleteCarCommandHandler> localizer)
    : IRequestHandler<DeleteCarCommand, CarDto>
{
    public async Task<CarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await carService.DeleteCarAsync(request.Id, cancellationToken);

        if (car == null) throw new NotFoundException(nameof(car), localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        return mapper.Map<CarDto>(car);
    }
}
