namespace Mac.CarHub.Application.Common.Models.DTOs;

public class CarVm
{
    public List<CarBriefDto> Cars { get; set; } = null!;

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }

    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
}
