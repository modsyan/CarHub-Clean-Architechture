using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mac.CarHub.Application.Brokers.Queries;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Infrastructure.Data;
using Mac.CarHub.Infrastructure.Identity;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Infrastructure.Services.Brokers;

public class BrokerService : IBrokerService
{
    private readonly ApplicationDbContext _context;
    private readonly IIdentityService _identityService;


    public BrokerService(ApplicationDbContext context,
        IIdentityService identityService)
    {
        _context = context;
        _identityService = identityService;
    }

    public Task<BrokerVm> GetBrokersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<(Broker, UserDetailsResponse?)?> GetBrokerAsync(Guid brokerId, CancellationToken cancellationToken)
    {
        var broker = await _context.Brokers
            .AsNoTracking()
            .Where(b => b.Id == brokerId)
            .Include(b => b.Cars).ThenInclude(c => c.Model).ThenInclude(m => m.Make)
            // .ProjectTo<BrokerDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (broker is null) return null;
        
        var userDetails = await _identityService.GetUserDetailsAsync(broker.UserId);

        return (broker, userDetails);
    }
}
