using System.Data;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Domain.Enums;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class EventDto
{
    public long Id { get; init; }

    public string EventTypeAsString { get; init; } = null!;
    
    public EventType EventType { get; init; }

    public string Description { get; init; } = null!;

    public CarBriefDto Car { get; init; } = null!;

    public DateTime Created { get; init; }

    public string CreatedBy { get; init; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Event, EventDto>()
                .ForMember(dest => dest.EventTypeAsString,
                    // opt => opt.MapFrom(src => src.EventType.ToString()));
                    //return capitalised key not the number of the enum
                    opt => opt.MapFrom(src => Enum.GetName(src.EventType)));
        }
    }
}
