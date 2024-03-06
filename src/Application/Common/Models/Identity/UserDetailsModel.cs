namespace Mac.CarHub.Application.Common.Models.Identity;

public class UserDetailsResponse
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; } 

    public string ProfilePicture { get; set; } = null!;
}
