using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Brokers.Queries;

public class BrokerVm
{
    public List<BrokerDto> Brokers { get; set; } = [];

    public int TotalCount { get; set; }
}
