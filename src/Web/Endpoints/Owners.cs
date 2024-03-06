using Microsoft.AspNetCore.Http.HttpResults;

namespace Mac.CarHub.Web.Endpoints;

public class Owners : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetOwners);
    }

    private static Ok<string> GetOwners(HttpContext context)
    {
        return TypedResults.Ok("Owners endpoint is working!");
    }
}
