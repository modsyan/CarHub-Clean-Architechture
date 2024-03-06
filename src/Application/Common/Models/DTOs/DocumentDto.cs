using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class DocumentDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public CarBriefDto Car { get; set; } = null!;
    
    public FileDto? File { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Document, DocumentDto>();
        }
    }
}
