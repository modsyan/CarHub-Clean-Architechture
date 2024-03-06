using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Domain.Common;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Domain.Enums;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class ReleaseRequestDto
{
    public Guid Id { get; set; }
    
    public string? Notes { get; set; }

    public RequestStatus Status { get; set; }
    
    public string StatusLocalized { get; set; } = null!;
    
    public CarDto Car { get; set; } = null!;
    
    public DateTime? RequestReleaseDate { get; set; } = DateTime.Now;
    
    public DateTime? AdminReleaseDate { get; set; }
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ReleaseRequest, ReleaseRequestDto>()
                .ForMember(
                    dest => dest.StatusLocalized,
                    opt => opt.MapFrom(src => src.Status.GetDisplayName())
                );
        }
    }
}
