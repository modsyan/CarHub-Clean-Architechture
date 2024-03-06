using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.ParkingSlots.Queries;

public record GetParkingSlotDetailsQuery(int Id) : IRequest<ParkingSlotDto>
{
}

public class GetParkingSlotDetailsQueryValidator : AbstractValidator<GetParkingSlotDetailsQuery>
{
    public GetParkingSlotDetailsQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetParkingSlotDetailsQueryValidator> localizer)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(async (id, cancellationToken) =>
                await context.ParkingSlots.AnyAsync(x => x.Id == id, cancellationToken))
            .WithMessage(localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }
}

public class GetParkingSlotDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetParkingSlotDetailsQuery, ParkingSlotDto>
{
    public async Task<ParkingSlotDto> Handle(GetParkingSlotDetailsQuery request, CancellationToken cancellationToken)
    {
        return await context
                   .ParkingSlots
                   .Include(p => p.Cars).ThenInclude(c => c.Model).ThenInclude(c => c.Make)
                   .Include(p => p.Cars).ThenInclude(c => c.Color)
                   .ProjectTo<ParkingSlotDto>(mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken) ??
               throw new NotFoundException(nameof(ParkingSlot), request.Id.ToString());
    }
}
