using System.Security.Claims;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Application.Lookups.Roles.Queries.GetRoles;
using Mac.CarHub.Application.Models;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using LoginRequest = Mac.CarHub.Application.Common.Models.Identity.LoginRequest;

namespace Mac.CarHub.Infrastructure.Identity;

public class IdentityService(
    UserManager<ApplicationUser> userManager,
    IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
    IAuthorizationService authorizationService,
    SignInManager<ApplicationUser> signInManager,
    IHostEnvironment hostEnvironment,
    IFileService fileService,
    RoleManager<ApplicationRole> roleManager

    // ,
    // TimeProvider timeProvider,
    // IOptionsMonitor<BearerTokenOptions> bearerTokenOptions,
    // IEmailSender<ApplicationUser> emailSender,
    // LinkGenerator linkGenerator
) : IIdentityService
{
    // private string? confirmEmailEndpointName = null;

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await userManager.Users.FirstAsync(u => Equals(u.Id, userId));

        return user.UserName;
    }

    public async Task<(Result Result, UserDetailsResponse? user)> CreateUserAsync(CreateUserCommand cmd,
        CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = cmd.UserName,
            Email = cmd.Email,
            FirstName = cmd.FirstName,
            LastName = cmd.LastName,
            PhoneNumber = cmd.PhoneNumber,
            NationalId = cmd.NationalId ?? string.Empty,
        };

        if (cmd.PersonalPhoto is not null)
        {
            user.ProfilePicture = await fileService.SaveToDiskAsync(cmd.PersonalPhoto, cancellationToken);
        }
        else if (cmd.DefaultAvatar is not null)
        {
            user.ProfilePicture = cmd.DefaultAvatar;
        }

        var result = await userManager.CreateAsync(user, cmd.Password);

        if (!result.Succeeded)
        {
            return (result.ToApplicationResult(), null);
        }

        var role = await userManager.AddToRoleAsync(user, cmd.RoleId);

        (_, UserDetailsResponse? userDetails) = await this.GetUserDetailsAsyncHandler(user.Id);
        return (role.ToApplicationResult(), userDetails);
    }

    public async Task<(Result Result, UserDetailsResponse? user)> UpdateUserAsync(EditUserCommand cmd,
        CancellationToken cancellationToken)
    {
        var user = await userManager.Users.SingleOrDefaultAsync(u => u.Id == cmd.Id, cancellationToken);

        if (user is null)
        {
            return (Result.Failure(new[] { "User not found" }), null);
        }

        if (cmd.Username != null) user.UserName = cmd.Username;

        if (!string.IsNullOrWhiteSpace(cmd.FistName))
            user.FirstName = cmd.FistName;

        if (!string.IsNullOrWhiteSpace(cmd.LastName))
            user.LastName = cmd.LastName;

        user.LastName = string.IsNullOrWhiteSpace(cmd.LastName) ? null : cmd.LastName;

        if (cmd.Email != null) user.Email = cmd.Email;

        if (cmd.NationalId != null) user.NationalId = cmd.NationalId;

        if (cmd.PhoneNumber != null) user.PhoneNumber = cmd.PhoneNumber;

        if (cmd.ProfilePicture is not null)
        {
            if (user.ProfilePicture is not null)
            {
                await fileService.DeleteFileAsync(user.ProfilePicture, cancellationToken);
            }

            user.ProfilePicture = await fileService.SaveToDiskAsync(cmd.ProfilePicture, cancellationToken);
        }

        var result = await userManager.UpdateAsync(user);

        (_, UserDetailsResponse? userDetails) = await this.GetUserDetailsAsyncHandler(user.Id);
        return (result.ToApplicationResult(), userDetails);
    }

    public async Task<bool> IsUsernameUniqueAsync(string username)
    {
        var user = await userManager.FindByNameAsync(username);

        return user is null;
    }

    public async Task<bool> IsUsernameUniqueExceptAsync(string username, Guid userId,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(username);

        return user is null || user.Id == userId;
    }

    public async Task<bool> IsEmailUniqueAsync(string email)
    {
        var user = await userManager.FindByEmailAsync(email);

        return user is null;
    }

    public async Task<UserDetailsResponse?> GetUserDetailsAsync(Guid userId)
    {
        (_, UserDetailsResponse? user) = await GetUserDetailsAsyncHandler(userId);

        return user;
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id.ToString() == userId);

        return user != null && await userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id.ToString() == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await userClaimsPrincipalFactory.CreateAsync(user);

        var result = await authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = userManager.Users.SingleOrDefault(u => u.Id.ToString() == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> AuthenticateAsync(LoginRequest request, bool useCookieScheme, bool isPersistent)
    {
        signInManager.AuthenticationScheme =
            useCookieScheme ? IdentityConstants.ApplicationScheme : IdentityConstants.BearerScheme;


        var user = await userManager.FindByNameAsync(request.UserName);

        if (user is null)
        {
            // for development purposes, we don't want to expose the fact that the user does not exist
            // return TypedResults.Problem("User not found", statusCode: StatusCodes.Status404NotFound);
            // must return at production unauthorized
            // return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);

            return Result.Failure(new[] { "User not found" });
        }


        var roles = await userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email!),
        };

        if (hostEnvironment.IsDevelopment())
        {
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10)
        };

        await signInManager.SignInWithClaimsAsync(user, isPersistent, claims);

        var result = await signInManager.PasswordSignInAsync(request.UserName, request.Password, isPersistent, false);

        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(request.TwoFactorCode))
            {
                result = await signInManager.TwoFactorAuthenticatorSignInAsync(request.TwoFactorCode, isPersistent,
                    rememberClient: isPersistent);
            }
            else if (!string.IsNullOrEmpty(request.TwoFactorRecoveryCode))
            {
                result = await signInManager.TwoFactorRecoveryCodeSignInAsync(request.TwoFactorRecoveryCode);
            }
        }

        if (!result.Succeeded)
        {
            // return TypedResults.Problem(result.ToString(), statusCode: StatusCodes.Status401Unauthorized);
            return Result.Failure(new[] { "Invalid password" });
        }

        return Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }

    // public async Task<Result> AuthenticateAsync(Models.LoginRequest  request, bool useCookieScheme, bool isPersistent)
    // {
    //     var user = await userManager.FindByNameAsync(request.UserName);
    //
    //     if (user == null)
    //     {
    //         return Result.Failure(new[] {"User not found"});
    //     }
    //
    //     var result = await userManager.CheckPasswordAsync(user, request.Password);
    //
    //     return result ? Result.Success() : Result.Failure(new[] {"Invalid password"});
    // }
    private async Task<(IList<string> roles, UserDetailsResponse? user)> GetUserDetailsAsyncHandler(Guid userId)
    {
        ArgumentNullException.ThrowIfNull(userId);

        var user = await userManager.Users
            .Include(u => u.ProfilePicture)
            .SingleOrDefaultAsync(u => u.Id == userId);

        ArgumentNullException.ThrowIfNull(user);


        var userResponse = new UserDetailsResponse
        {
            Id = user.Id,
            UserName = user.UserName ?? "",
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            NationalId = user.NationalId,
        };

        if (user.ProfilePicture is not null)
        {
            userResponse.ProfilePicture = user.ProfilePicture.FilePath;
        }

        var roles = await userManager.GetRolesAsync(user);

        return (roles, userResponse);
    }

    public async Task<RoleVm> GetRolesAsync(CancellationToken cancellationToken)
    {
        var roles = await roleManager
            .Roles
            .Select(r => new RoleDto { Id = r.Id.ToString(), Name = r.Name! })
            .ToListAsync(cancellationToken);

        return new RoleVm { Roles = roles };
    }
}
