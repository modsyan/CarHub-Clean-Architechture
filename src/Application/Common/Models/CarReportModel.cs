using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models;

public class CarReportModel
{
    public List<Car> EnteredCars { get; set; } = [];
    public List<Event> OverallActivities { get; set; } = [];
}
