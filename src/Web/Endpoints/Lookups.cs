using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Lookups.Colors.Queries;
using Mac.CarHub.Application.Lookups.Makes.Queries;
using Mac.CarHub.Application.Lookups.Models.Queries;
using Mac.CarHub.Application.Lookups.Overalls.Queries;
using Mac.CarHub.Application.Lookups.Roles.Queries.GetRoles;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Lookups : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .AllowAnonymous()
            .MapGet(GetColors, "colors")
            .MapGet(GetMakes, "makes")
            .MapGet(GetModels, "models")
            .MapGet(GetOverall, "overall")
            .MapGet(GetRoles, "roles")
            ;
    }

    private static async Task<Ok<ColorVm>> GetColors(ISender sender)
    {
        var result = await sender.Send(new GetColorsQuery());

        return TypedResults.Ok(result);
    }

    private static async Task<Ok<MakeVm>> GetMakes(
        ISender sender,
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize,
        [FromQuery] string? searchString
    )
    {
        var query = new GetMakesQuery { PageNumber = pageNumber, PageSize = pageSize, SearchString = searchString };

        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    private static async Task<Ok<ModelVm>> GetModels(
        ISender sender,
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize,
        [FromQuery] string? searchString,
        [FromQuery] int? makeId
    )
    {
        var query = new GetModelsQuery
        {
            PageNumber = pageNumber, PageSize = pageSize, SearchString = searchString, MakeId = makeId
        };

        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    private static async Task<Ok<OverallDto>> GetOverall(ISender sender)
    {
        var result = await sender.Send(new GetOverallQuery());

        return TypedResults.Ok(result);
    }

    private static async Task<Ok<RoleVm>> GetRoles(ISender sender)
    {
        var result = await sender.Send(new GetRolesQuery());

        return TypedResults.Ok(result);
    }
}
