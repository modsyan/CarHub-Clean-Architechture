using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Application.Lookups.Roles.Queries.GetRoles;
using Mac.CarHub.Application.Models;

namespace Mac.CarHub.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, UserDetailsResponse? user)> CreateUserAsync(CreateUserCommand cmd, CancellationToken cancellationToken);
    
    Task<(Result Result, UserDetailsResponse? user)> UpdateUserAsync(EditUserCommand cmd, CancellationToken cancellationToken);
    
    Task<bool> IsUsernameUniqueAsync(string username);
    
    Task<bool> IsUsernameUniqueExceptAsync(string username, Guid userId, CancellationToken cancellationToken);
    
    Task<bool> IsEmailUniqueAsync(string email);
    
    //get user details 
    Task<UserDetailsResponse?> GetUserDetailsAsync(Guid userId);
    
    // Task<List<UserDetailsResponse>> GetUserDetailsAsync(List<string> userIds);
    
    Task<Result> DeleteUserAsync(string userId);

    Task<Result> AuthenticateAsync(LoginRequest request, bool useCookieScheme, bool isPersistent);
    
    Task<RoleVm> GetRolesAsync(CancellationToken cancellationToken);
}
