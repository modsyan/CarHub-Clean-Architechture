using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.ParkingSlots.Commands.EditParkingSlot;

public record EditParkingSlotCommand : IRequest<ParkingSlotDto>
{
    public int Id { get; init; }

    public string? Name { get; init; }

    public string? Description { get; init; }

    public int? Capacity { get; init; }
}

public class EditParkingSlotCommandValidator : AbstractValidator<EditParkingSlotCommand>
{
    public EditParkingSlotCommandValidator(IStringLocalizer<EditParkingSlotCommandValidator> localizer)
    {
        RuleFor(s => s.Id)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(s => s.Name)
            .MaximumLength(50).WithMessage(localizer[SharedResourcesKeys.ERR_MAX_LENGTH, 50]);

        RuleFor(s => s.Description)
            .MaximumLength(50).WithMessage(localizer[SharedResourcesKeys.ERR_MAX_LENGTH, 200]);

        RuleFor(s => s.Capacity)
            .GreaterThan(0).WithMessage(localizer[SharedResourcesKeys.ERR_OUT_OF_RANGE]);
    }
}

public class EditParkingSlotCommandHandler : IRequestHandler<EditParkingSlotCommand, ParkingSlotDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public EditParkingSlotCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParkingSlotDto> Handle(EditParkingSlotCommand request, CancellationToken cancellationToken)
    {
        var parkingSlot = await _context.ParkingSlots
                              .Where(p => p.Id == request.Id)
                              .FirstOrDefaultAsync(cancellationToken)
                          ?? throw new NotFoundException(nameof(ParkingSlot), request.Id.ToString());

        parkingSlot.Title = request.Name ?? parkingSlot.Title;
        parkingSlot.Description = request.Description ?? parkingSlot.Description;
        parkingSlot.Capacity = request.Capacity ?? parkingSlot.Capacity;

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ParkingSlotDto>(parkingSlot);
    }
}
