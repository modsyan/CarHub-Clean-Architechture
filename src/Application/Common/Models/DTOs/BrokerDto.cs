using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Domain.Entities;

namespace Mac.CarHub.Application.Common.Models.DTOs;

public class BrokerDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public UserDetailsResponse? UserDetails { get; set; } = null!; // manually added TODO: Fix this

    public ICollection<CarBriefDto> Cars { get; init; } = [];

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Broker, BrokerDto>()
                // .ForMember(dest => dest.Cars,)
                ;
        }
    }
}
