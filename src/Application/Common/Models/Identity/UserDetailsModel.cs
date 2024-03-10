namespace Mac.CarHub.Application.Common.Models.Identity;

public class UserDetailsResponse
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string? FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; } = string.Empty;

    public string? NationalId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string ProfilePicture { get; set; } = null!;
}
