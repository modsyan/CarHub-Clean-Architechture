using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Releasing.Commands;
using Mac.CarHub.Application.Releasing.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Releasing : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetReleasedCars)
            .MapGet(GetReleasedCarDetails, "{carId:guid}")
            .MapPost(ReleaseCar)
            .MapPut(EditRelease, "{carId:guid}")
            .MapDelete(DeleteRelease, "{carId:guid}");
        ;
    }

    private static async Task<Ok<ReleaseVm>> GetReleasedCars(ISender sender)
    {
        var result = await sender.Send(new GetReleasedCarsQuery());

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<ReleaseDto>, NotFound>> GetReleasedCarDetails(ISender sender,
        [FromRoute] Guid carId)
    {
        var result = await sender.Send(new GetReleasedCarDetailsQuery(carId));

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Created<ReleaseDto>, BadRequest<string>>> ReleaseCar(ISender sender,
        Guid carId,
        DateTime? releaseDate,
        [FromForm] IFormFile documents)
        // [FromForm] IFormFileCollection documents)
    
    {
        // var command = new ReleaseCarCommand { Id = carId, ReleaseDate = releaseDate, Documents = documents.ToList() };
        var command = new ReleaseCarCommand { Id = carId, ReleaseDate = releaseDate, Documents = [documents] };

        var result = await sender.Send(command);

        return TypedResults.Created(new Uri($"/api/Releasing/{result.Id}", UriKind.Relative), result);
    }

    private static async Task<Results<Ok<ReleaseDto>, NotFound, BadRequest<string>>> EditRelease(ISender sender,
        [FromRoute] Guid carId,
        [FromBody] EditReleaseCommand command)
    {
        if (command.CarId != carId) return TypedResults.BadRequest("Id mismatch");

        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<ReleaseDto>, NotFound, BadRequest<string>>> DeleteRelease(ISender sender,
        [FromRoute] Guid carId)
    {
        var result = await sender.Send(new DeleteReleaseCommand(carId));

        return TypedResults.Ok(result);
    }
}
