using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Mac.CarHub.Infrastructure.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // public string UserName { get; set; }

    public Guid ProfilePictureId { get; set; }
    public UploadedFile ProfilePicture { get; set; } = null!;

    public string? FullName => $"{FirstName} {LastName}";
}
