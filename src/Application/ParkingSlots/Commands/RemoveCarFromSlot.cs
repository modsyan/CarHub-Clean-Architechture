using Mac.CarHub.Application.Common.Exceptions;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.ParkingSlots.Commands;

public record RemoveCarFromSlotCommand(Guid CarId) : IRequest<ParkingSlotDto>
{
}

public class RemoveCarFromSlotCommandValidator : AbstractValidator<RemoveCarFromSlotCommand>
{
    public RemoveCarFromSlotCommandValidator(IStringLocalizer<RemoveCarFromSlotCommandValidator> localizer)
    {
        RuleFor(s => s.CarId)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class RemoveCarFromSlotCommandHandler : IRequestHandler<RemoveCarFromSlotCommand, ParkingSlotDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<RemoveCarFromSlotCommandHandler> _localizer;

    public RemoveCarFromSlotCommandHandler(IApplicationDbContext context, IMapper mapper, IStringLocalizer<RemoveCarFromSlotCommandHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<ParkingSlotDto> Handle(RemoveCarFromSlotCommand request, CancellationToken cancellationToken)
    {
        var car = await _context.Cars
                      .Include(c => c.ParkingSlot)
                      .FirstOrDefaultAsync(c => c.Id == request.CarId, cancellationToken)
                  ?? throw new NotFoundException(nameof(Car), request.CarId.ToString());

        if (car.ParkingSlot == null)
            throw new BadRequestException(_localizer[SharedResourcesKeys.ERR_CAR_NOT_PARKED]);

        car.ParkingSlot.Cars.Remove(car);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ParkingSlotDto>(car.ParkingSlot);
    }
}
