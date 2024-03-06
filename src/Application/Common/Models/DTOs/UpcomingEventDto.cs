using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Domain.Enums;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class UpcomingEventDto
{
    public CarBriefDto Car { get; set; } = null!;

    public string Type { get; set; } = null!;

    public DateTime Date { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Car, UpcomingEventDto>()
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Release!.ReleaseDate)
                )
                // .ForMember(
                //     dest => dest.Make,
                //     opt => opt.MapFrom(src => src.Car.Model.Name))
                // .ForMember(
                //     dest => dest.Model,
                //     opt => opt.MapFrom(src => src.Car.Model.Make.Name))
                // .ForMember(
                //     dest => dest.Description,
                //     opt => opt.Ignore()
                // )
                // .ForMember(
                //     dest => dest.Color,
                //     opt => opt.MapFrom(src => src.Car.Color.Localized())
                // )
                .ForMember(
                    dest => dest.Car,
                    opt => opt.MapFrom(src => src)
                )
                
                .ForMember(
                    dest => dest.Type,
                    opt => opt.MapFrom(src =>
                        src.Release != null
                            ? EventType.Release.GetDisplayName()
                            : EventType.Other.GetDisplayName()))
                ;
        }
    }
}
