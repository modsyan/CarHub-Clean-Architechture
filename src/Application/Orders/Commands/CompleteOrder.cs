using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Domain.Enums;

namespace Mac.CarHub.Application.Orders.Commands;

public record CompleteOrderCommand(Guid OrderId) : IRequest<CarDto>;

public class CompleteOrderCommandHandler(IApplicationDbContext context, ICarService carService, IMapper mapper)
    : IRequestHandler<CompleteOrderCommand, CarDto>
{
    public async Task<CarDto> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
    {
        var car = await carService.GetCarDetails(request.OrderId, cancellationToken) ??
                  throw new NotFoundException(nameof(Car), request.OrderId.ToString());

        car.Status = CarStatus.Completed;

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CarDto>(car);
    }
}
