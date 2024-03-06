using Microsoft.AspNetCore.Http;

namespace Mac.CarHub.Application.Common.Models.Identity;

public class EditUserCommand
{
    public Guid Id { get; init; }

    public string? Name { get; init; } = null!;

    public string? Username { get; init; } = null!;

    public string? Email { get; init; } = null!;

    public string? PhoneNumber { get; init; } = null!;

    public string? NationalId { get; init; } = null!;

    public IFormFile? ProfilePicture { get; init; } = null!;
}
