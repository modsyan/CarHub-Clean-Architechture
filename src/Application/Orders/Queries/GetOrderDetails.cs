using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.StoredCarOrders.Queries.GetStoredCarOrderDetails;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Orders.Queries;

public record GetOrderDetailsQuery(Guid Id) : IRequest<OrderDto>;

public class GetOrderDetailsQueryValidator : AbstractValidator<GetOrderDetailsQuery>
{
    public GetOrderDetailsQueryValidator()
    {
    }
}

public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetOrderDetailsQueryHandler> _localizer;

    public GetOrderDetailsQueryHandler(IApplicationDbContext context, IMapper mapper,
        IStringLocalizer<GetOrderDetailsQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public Task<OrderDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = _context.Cars
            .Include(c => c.Model).ThenInclude(o => o.Make)
            .Include(c => c.Color)
            .Include(o => o.Inspections).ThenInclude(i => i.File)
            .FirstOrDefault(o => o.Id == request.Id);

        if (entity == null)
        {
            throw new NotFoundException(_localizer["Order"], request.Id.ToString());
        }

        return Task.FromResult(_mapper.Map<OrderDto>(entity));
    }
}
