namespace Mac.CarHub.Application.Common.Models.Identity;

public class LoginRequest
{
    public required string UserName { get; init; }
    public required string Password { get; init; }
    public string? TwoFactorCode { get; init; }
    public string? TwoFactorRecoveryCode { get; init; }
}
