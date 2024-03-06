using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class CarDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string EngineSerialNumber { get; set; } = null!;

    public List<InspectionBriefDto> Inspections { get; set; } = null!;

    public List<DocumentBriefDto> Documents { get; set; } = null!;

    public OwnerDto Owner { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool IsReleased { get; set; }

    public ReleaseDto Release { get; set; } = null!;

    public UserDetailsResponse OwnerDetails { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Car, CarDto>()
                .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Model.Make.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(dest => dest.IsReleased, opt => opt.MapFrom(src => src.Release != null))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.Localized()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDisplayName()))
                ;
        }
    }
}
