namespace Mac.CarHub.Application.Common.Models.DTOs;

public class ModelVm
{
    public List<ModelDto> Models { get; set; } = null!;
    public int TotalCount { get; set; }
    
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
