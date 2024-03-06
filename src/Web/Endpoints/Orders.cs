using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Orders.Commands;
using Mac.CarHub.Application.Orders.Queries;
using Mac.CarHub.Application.StoredCarOrders.Queries.GetStoredCarOrderDetails;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Orders : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetOrders)
            .MapGet(GetOrderDetails, "{id:guid}");

        app.MapGroup(this)
            .MapPost(LaunchOrder)
            .MapPost(CompleteOrder, "complete/{id:guid}");
    }

    #region Orders

    private static async Task<Results<Ok<OrderVm>, BadRequest<string>>> GetOrders(ISender sender,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string searchString = "",
        [FromQuery] string sortBy = "Date",
        [FromQuery] string sortOrder = "asc",
        [FromQuery] bool isCompletedOnly = false
    )
    {
        var query = new GetOrdersQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            SearchString = searchString,
            SortBy = sortBy,
            IsCompletedOnly = isCompletedOnly
        };

        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<OrderDto>, NotFound>> GetOrderDetails(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new GetOrderDetailsQuery(id));

        return TypedResults.Ok(result);
    }

    private static async Task<Created<CarDto>> LaunchOrder(ISender sender,
        [AsParameters] LaunchOrderCommand command)
    {
        var result = await sender.Send(command);

        return TypedResults.Created(new Uri($"/api/Orders/{result.Id}", UriKind.Relative), result);
    }

    private static async Task<Results<Ok<CarDto>, BadRequest<string>>> CompleteOrder(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new CompleteOrderCommand(id));

        return TypedResults.Ok(result);
    }

    #endregion
}
