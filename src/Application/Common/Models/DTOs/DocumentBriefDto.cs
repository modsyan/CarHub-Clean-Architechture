using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class DocumentBriefDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string File { get; set; } =  string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Document, DocumentBriefDto>()
                .ForMember(dest => dest.File,
                    opt => opt.MapFrom(src => src.File != null ? src.File.FilePath : string.Empty));
        }
    }
}
