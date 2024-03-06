using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.ParkingSlots.Commands;

public record CreateParkingSlotCommand : IRequest<ParkingSlotDto>
{
    public string Title { get; set; } = String.Empty;
    public int Capacity { get; set; }
    public string Description { get; set; } = String.Empty;
}

public class CreateParkingSlotCommandValidator : AbstractValidator<CreateParkingSlotCommand>
{
    public CreateParkingSlotCommandValidator(IStringLocalizer<CreateParkingSlotCommandValidator> localizer)
    {
        RuleFor(s => s.Title)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MaximumLength(50).WithMessage(localizer[SharedResourcesKeys.ERR_MAX_LENGTH, 50]);

        RuleFor(s => s.Capacity)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED])
            .GreaterThan(0).WithMessage(localizer[SharedResourcesKeys.ERR_OUT_OF_RANGE]);

        RuleFor(s => s.Description)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MaximumLength(50).WithMessage(localizer[SharedResourcesKeys.ERR_MAX_LENGTH, 200]);
    }
}

public class CreateParkingSlotCommandHandler : IRequestHandler<CreateParkingSlotCommand, ParkingSlotDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateParkingSlotCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ParkingSlotDto> Handle(CreateParkingSlotCommand request, CancellationToken cancellationToken)
    {
        var entity = new ParkingSlot
        {
            Title = request.Title, Capacity = request.Capacity, Description = request.Description
        };

        _context.ParkingSlots.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ParkingSlotDto>(entity);
    }
}
