using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class InspectionBriefDto
{
    public Guid Id { get; set; }

    public string Text { get; set; } = String.Empty;

    public string File { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Inspection, InspectionBriefDto>()
                .ForMember(dest => dest.File, opt => opt.MapFrom(src => src.File.FilePath));
        }
    }
}
