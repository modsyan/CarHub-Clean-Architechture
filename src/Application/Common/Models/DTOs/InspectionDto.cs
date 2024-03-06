using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class InspectionDto
{
    public Guid Id { get; set; }
    
    public string Text { get; set; } = String.Empty;
    
    public CarBriefDto? Car { get; set; } = null!;
    
    public FileDto File { get; set; } = null!;
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Inspection, InspectionDto>();
        }
    }
}
