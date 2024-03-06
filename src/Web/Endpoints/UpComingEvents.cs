using System.Runtime.InteropServices.JavaScript;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.UpcomingEvents.Queries;
using Mac.CarHub.Application.UpcomingEvents.Queries.GetUpcomingEventDetails;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class UpComingEvents : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetUpcomingEvents)
            .MapGet(GetUpcomingEventDetails, "{date:datetime}");
    }

    private async static Task<Ok<UpcomingEventVm>> GetUpcomingEvents(ISender sender,
        [FromQuery] DateTime? startDate ,
        [FromQuery] DateTime? endDate,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortOrder = "asc")
    {
        var result = await sender.Send(new GetUpcomingEventsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SortOrder = sortOrder,
            StartDate = startDate?? DateTime.Now.AddDays(-30),
            EndDate = endDate ?? DateTime.Now
        });

        return TypedResults.Ok(result);
    }

    private async static Task<Results<Ok<UpcomingEventVm>, NotFound>> GetUpcomingEventDetails(ISender sender,
        [FromRoute] DateTime date)
    {
        var result = await sender.Send(new GetUpcomingEventDetailsQuery(date));

        return TypedResults.Ok(result);
    }
}
