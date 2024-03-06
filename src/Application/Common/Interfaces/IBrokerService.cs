using System.Linq.Expressions;
using Mac.CarHub.Application.Brokers.Queries;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface IBrokerService
{
    Task<BrokerVm> GetBrokersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    Task<(Broker, UserDetailsResponse?)?> GetBrokerAsync(Guid brokerId, CancellationToken cancellationToken);

    // Task<BrokerDto> GetBrokerAsync(int brokerId, params Expression<Func<Broker, object>>[] includes);
}
