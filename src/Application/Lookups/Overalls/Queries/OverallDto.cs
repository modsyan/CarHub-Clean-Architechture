using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Lookups.Overalls.Queries;

public class OverallDto
{
    public int EnteredCarsToday { get; set; }
    public int EnteredCarsThisMonth { get; set; }
    public int EnteredCarsThisYear { get; set; }
    
    public int TotalCars { get; set; }
    
    public List<BrokerDto> TopBrokers { get; set; } = [];
}
