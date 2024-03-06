using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class ReleaseDto
{
    public Guid Id { get; set; }

    public DateTime ReleaseDate { get; set; }

    public CarBriefDto Car { get; set; } = null!;

    public List<string> Documents { get; set; } = new();

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Release, ReleaseDto>()
                .ForMember(
                    dest => dest.Documents,
                    opt => opt.MapFrom(src =>
                        src.Documents.Select(d =>
                        d.Image == null ? "" : d.Image.FilePath).ToList())
                    );
        }
    }
}
