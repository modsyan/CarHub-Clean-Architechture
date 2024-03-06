using Mac.CarHub.Application.Cars.Commands;
using Mac.CarHub.Application.Cars.Queries;
using Mac.CarHub.Application.Common.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Cars : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCars)
            .MapGet(GetCarDetails, "{id:guid}")
            .MapPut(EditCar, "{id:guid}")
            .MapDelete(DeleteCar, "{id:guid}");
    }

    private static async Task<Results<Ok<CarDto>, BadRequest<string>>> GetCarDetails(ISender sender,
        [FromRoute] Guid id)
    {
        var query = await sender.Send(new GetCarDetailsQuery(id));

        return TypedResults.Ok(query);
    }

    private static async Task<Results<Ok<CarVm>, BadRequest<string>>> GetCars(ISender sender,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string searchString = ""
    )
    {
        var result = await sender.Send(new GetCarsQuery
        {
            PageNumber = pageNumber, PageSize = pageSize, SearchString = searchString
        });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<CarDto>, NotFound, BadRequest<string>>> EditCar(ISender sender,
        [FromRoute] Guid id,
        [FromBody] EditCarCommand command)
    {
        if (command.Id != id) return TypedResults.BadRequest("Id mismatch");

        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<CarDto>, BadRequest<string>>> DeleteCar(ISender sender,
        [FromRoute] Guid id)
    {
        var response = await sender.Send(new DeleteCarCommand(id));

        return TypedResults.Ok(response);
    }
}
