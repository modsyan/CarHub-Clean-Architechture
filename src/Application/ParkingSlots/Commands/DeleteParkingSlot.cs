using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.ParkingSlots.Commands.DeleteParkingSlot;

public record DeleteParkingSlotCommand(int Id) : IRequest<ParkingSlotDto>
{
}

public class DeleteParkingSlotCommandValidator : AbstractValidator<DeleteParkingSlotCommand>
{
    public DeleteParkingSlotCommandValidator(IStringLocalizer<DeleteParkingSlotCommandValidator> localizer)
    {
        RuleFor(s => s.Id)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class DeleteParkingSlotCommandHandler : IRequestHandler<DeleteParkingSlotCommand, ParkingSlotDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DeleteParkingSlotCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParkingSlotDto> Handle(DeleteParkingSlotCommand request, CancellationToken cancellationToken)
    {
        var parkingSlot =
            await _context.ParkingSlots
                .Where(p => p.Id == request.Id)
                .Include(p => p.Cars)
                .FirstOrDefaultAsync(cancellationToken) ??
            throw new NotFoundException(nameof(ParkingSlot), request.Id.ToString());

        _context.ParkingSlots.Remove(parkingSlot);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ParkingSlotDto>(parkingSlot);
    }
}
