using System.Data.Common;
using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class ModelDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = String.Empty;

    public MakeDto Make { get; set; } = null!;

    private class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model, ModelDto>();
        }
    }
}
