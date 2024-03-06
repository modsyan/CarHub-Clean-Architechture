using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class CarBriefDto
{
    public Guid Id { get; set; }

    public string MakeName { get; set; } = null!;

    public string ModelName { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string Color { get; set; } = null!;

    public int InspectionCount { get; set; }
    public int DocumentCount { get; set; }

    public string Status { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Car, CarBriefDto>()
                .ForMember(dest => dest.MakeName,
                    opt => opt.MapFrom(src => src.Model.Make.Name))
                .ForMember(
                    dest => dest.ModelName,
                    opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(
                    dest => dest.InspectionCount,
                    opt => opt.MapFrom(src => src.Inspections.Count))
                .ForMember(
                    dest => dest.DocumentCount,
                    opt => opt.MapFrom(src => src.Documents.Count))
                .ForMember(
                    dest => dest.Color,
                    opt => opt.MapFrom(src => src.Color.Localized()))
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.GetDisplayName())
                );
        }
    }
}
