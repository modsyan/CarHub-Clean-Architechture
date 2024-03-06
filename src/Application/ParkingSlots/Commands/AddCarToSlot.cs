using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.ParkingSlots.Commands;

public record AddCarToSlotCommand : IRequest<ParkingSlotDto>
{
    public int SlotId { get; init; }
    public Guid CarId { get; init; }
}

public class AddCarToSlotCommandValidator : AbstractValidator<AddCarToSlotCommand>
{
    private readonly IStringLocalizer<AddCarToSlotCommandValidator> _localizer;

    public AddCarToSlotCommandValidator(IStringLocalizer<AddCarToSlotCommandValidator> localizer)
    {
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(s => s.CarId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(s => s.SlotId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class AddCarToSlotCommandHandler : IRequestHandler<AddCarToSlotCommand, ParkingSlotDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AddCarToSlotCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParkingSlotDto> Handle(AddCarToSlotCommand request, CancellationToken cancellationToken)
    {
        var parkingSlot = await _context.ParkingSlots
            .Include(p => p.Cars)
            .FirstOrDefaultAsync(p => p.Id == request.SlotId, cancellationToken)
            ?? throw new NotFoundException(nameof(ParkingSlot), request.SlotId.ToString());

        var car = await _context.Cars
            .FirstOrDefaultAsync(c => c.Id == request.CarId, cancellationToken)
            ?? throw new NotFoundException(nameof(Car), request.CarId.ToString());

        parkingSlot.Cars.Add(car);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ParkingSlotDto>(parkingSlot);
    }
}
