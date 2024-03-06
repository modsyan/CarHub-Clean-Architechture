using AutoMapper;

namespace Mac.CarHub.Infrastructure.Identity;

public class ApplicationUserDto
{

    public int Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FullName { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => $"{s.FirstName} {s.LastName}"));
        }
    }
}
