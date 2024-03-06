using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;

namespace Mac.CarHub.Application.Brokers.Queries;

public record GetBrokerQuery(Guid Id) : IRequest<BrokerDto>;

public class GetBrokerQueryValidator : AbstractValidator<GetBrokerQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetBrokerQueryValidator> _localizer;

    public GetBrokerQueryValidator(IApplicationDbContext context, IStringLocalizer<GetBrokerQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyRules();
    }

    private void ApplyRules()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(BeValidBrokerId).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }

    private async Task<bool> BeValidBrokerId(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Brokers.AnyAsync(b => b.Id == id, cancellationToken);
    }
}

public class GetBrokerQueryHandler : IRequestHandler<GetBrokerQuery, BrokerDto>
{
    // private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetBrokerQueryHandler> _localizer;
    // private readonly IIdentityService _identityService;

    private readonly IBrokerService _brokerService;

    public GetBrokerQueryHandler(
        // IApplicationDbContext context,
        IMapper mapper,
        IStringLocalizer<GetBrokerQueryHandler> localizer,
        // IIdentityService identityService,
        IBrokerService brokerService
    )
    {
        // _context = context;
        _mapper = mapper;
        _localizer = localizer;
        // _identityService = identityService;
        _brokerService = brokerService;
    }

    public async Task<BrokerDto> Handle(GetBrokerQuery request, CancellationToken cancellationToken)
    {
        // var broker = await _context.Brokers
        //     .AsNoTracking()
        //     .Where(b => b.Id == request.Id)
        //     .Include(b => b.Cars)
        //     .ProjectTo<BrokerDto>(_mapper.ConfigurationProvider)
        //     .SingleOrDefaultAsync(cancellationToken);
        //
        // if (broker == null)
        // {
        //     throw new NotFoundException(_localizer[SharedResourcesKeys._ERR_NOT_FOUND], request.Id.ToString());
        // }
        //
        // var brokerUserId = await _context.Brokers
        //     .Where(b => b.Id == request.Id)
        //     .Select(b => b.UserId)
        //     .SingleAsync(cancellationToken);
        //
        // broker.UserDetails = await _identityService.GetUserDetailsAsync(brokerUserId)
        //                      ?? throw new NotFoundException(_localizer[SharedResourcesKeys._ERR_NOT_FOUND],
        //                          brokerUserId);
        // return broker;

        (Broker broker, UserDetailsResponse? userDetailsResponse) result =
            await _brokerService.GetBrokerAsync(request.Id, cancellationToken) ??
            throw new NotFoundException(_localizer[SharedResourcesKeys.ERR_NOT_FOUND], request.Id.ToString());

        var brokerDto = _mapper.Map<BrokerDto>(result.broker);

        brokerDto.UserDetails = result.userDetailsResponse ?? throw new NotFoundException(
            _localizer[SharedResourcesKeys.ERR_NOT_FOUND], result.broker.UserId.ToString());

        return brokerDto;
    }
}
