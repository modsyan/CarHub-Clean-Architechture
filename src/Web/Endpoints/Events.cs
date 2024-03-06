using Mac.CarHub.Application.CarEvents.Queries;
using Mac.CarHub.Application.Common.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Events : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetEvents)
            .MapGet(GetEventDetail, "{id:guid}");
    }

    private static async Task<Results<Ok<EventVm>, BadRequest<string>>> GetEvents(
        ISender sender,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string searchString = "",
        [FromQuery] string sortBy = "Date",
        [FromQuery] string sortOrder = "asc"
    )
    {
        var query = new GetCarEventsQuery
        {
            PageNumber = pageNumber, PageSize = pageSize, SearchString = searchString, SortBy = sortBy,
        };

        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<EventDto>, NotFound>> GetEventDetail(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new GetCarEventDetailsQuery(id));

        return TypedResults.Ok(result);
    }
}
