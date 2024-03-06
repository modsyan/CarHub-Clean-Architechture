using Mac.CarHub.Application.Brokers.Queries;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Brokers.Commands;

public record DeleteBrokerCommand(Guid Id) : IRequest<BrokerDto>;

public class DeleteBrokerCommandHandler : IRequestHandler<DeleteBrokerCommand, BrokerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<DeleteBrokerCommandHandler> _localizer;
    private readonly IMapper _mapper;


    public DeleteBrokerCommandHandler(IApplicationDbContext context, IMapper mapper,
        IStringLocalizer<DeleteBrokerCommandHandler> localizer)
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
    }

    public async Task<BrokerDto> Handle(DeleteBrokerCommand request, CancellationToken cancellationToken)
    {
        var broker =
            await _context.Brokers.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (broker is null) throw new NotFoundException(nameof(Broker), request.Id.ToString());

        _context.Brokers.Remove(broker);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<BrokerDto>(broker);
    }
}
