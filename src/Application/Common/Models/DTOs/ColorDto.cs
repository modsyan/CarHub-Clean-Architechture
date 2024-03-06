using System.Globalization;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class ColorDto
{
    public int Id { get; set; }
    public string LocalizedName { get; set; } = null!;

    private class Mapping : Profile
    {
        public Mapping()
        {
            var culture = CultureInfo.CurrentCulture.Name;

            CreateMap<Color, ColorDto>()
                .ForMember(dest => dest.LocalizedName,
                    opt => opt.MapFrom(src => culture == "en-US" ? src.EnName : src.ArName))
                ;
        }
    }
}
