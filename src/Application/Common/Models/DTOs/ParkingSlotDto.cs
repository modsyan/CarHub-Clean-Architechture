using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class ParkingSlotDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }

    public int Capacity { get; set; }

    public List<CarBriefDto> Cars { get; set; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ParkingSlot, ParkingSlotDto>()
                .ForMember(d => d.IsAvailable,
                    opt => opt.MapFrom(s => s.Cars.Count < s.Capacity));
        }
    }
}
