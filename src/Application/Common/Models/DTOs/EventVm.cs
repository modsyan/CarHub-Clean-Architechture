namespace Mac.CarHub.Application.Common.Models.DTOs;

public class EventVm
{
    public List<EventDto> Events { get; set; } = [];
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
