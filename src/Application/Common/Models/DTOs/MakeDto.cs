using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class MakeDto
{

    public int Id { get; set; }
    
    public string Name { get; set; } = String.Empty;

    public List<ModelDto> Models { get; set; } = [];
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Make, MakeDto>();
        }
    }
}
