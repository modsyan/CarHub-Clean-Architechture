using System.Security.Claims;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Mappings;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Application.Models;
using Mac.CarHub.Infrastructure.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetUsers)
            .MapGet(GetMe, "me")
            .MapPost(CreateUser);
    }

    private static async Task<Results<Created<Guid>, BadRequest<string[]>>> CreateUser(
        ISender sender, IIdentityService identityService, [FromBody] CreateUserCommand cmd)
    {
        (Result result, UserDetailsResponse? user) =
            await identityService.CreateUserAsync(cmd, cancellationToken: CancellationToken.None);

        if (user is null || result.Succeeded == false) return TypedResults.BadRequest(result.Errors);

        return TypedResults.Created($"/api/users/{user.Id.ToString()}", user.Id);
    }

    private static async Task<Ok<PaginatedList<ApplicationUserDto>>> GetUsers(
        [FromServices] UserManager<ApplicationUser> userManager,
        [FromServices] IMapper mapper,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var users = await userManager
            .Users
            .ProjectTo<ApplicationUserDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(pageNumber, pageSize);

        return TypedResults.Ok(users);
    }

    private static async Task<Results<Ok<UserDetailsResponse>, NotFound>> GetMe(
        [FromServices] UserManager<ApplicationUser> userManager,
        [FromServices] IIdentityService identityService,
        [FromServices] IMapper mapper,
        [FromServices] IHttpContextAccessor httpContextAccessor,
        ClaimsPrincipal currentUser
    )
    {
        var httpAccessor = httpContextAccessor.HttpContext;

        if (httpAccessor is null) return TypedResults.NotFound();

        // var user = await userManager.GetUserAsync(currentUser.Identity!.Name!);

        var user = await userManager.GetUserAsync(httpAccessor.User);

        if (user is null) return TypedResults.NotFound();

        var userDetails = await identityService.GetUserDetailsAsync(user.Id);

        return TypedResults.Ok(userDetails);
    }
}
