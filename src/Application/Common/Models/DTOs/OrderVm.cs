using Mac.CarHub.Application.StoredCarOrders.Queries.GetStoredCarOrderDetails;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class OrderVm
{
    public PaginatedList<CarBriefDto> List { get; set; } = null!;
}
