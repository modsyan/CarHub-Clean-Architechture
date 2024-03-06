using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.ParkingSlots.Commands;
using Mac.CarHub.Application.ParkingSlots.Commands.DeleteParkingSlot;
using Mac.CarHub.Application.ParkingSlots.Commands.EditParkingSlot;
using Mac.CarHub.Application.ParkingSlots.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class ParkingSlots : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetParkingSlots)
            .MapGet(GetParkingSlotDetails, "{id:int}")
            .MapPost(AddParkingSlot)
            .MapPut(EditParkingSlot, "{id:int}")
            .MapDelete(DeleteParkingSlot, "{id:int}");

        app.MapGroup(this)
            .MapPost(AddCarToSlot, "{id:int}/cars")
            .MapDelete(RemoveCarFromSlot, "cars/{carId:guid}");
    }

    #region ParkingSlotOperations

    private static async Task<Ok<PaginatedList<ParkingSlotDto>>> GetParkingSlots(ISender sender,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10
    )
    {
        var query = new GetParkingSlotsQuery { PageNumber = pageNumber, PageSize = pageSize };

        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<ParkingSlotDto>, NotFound>> GetParkingSlotDetails(ISender sender,
        [FromRoute] int id)
    {
        var result = await sender.Send(new GetParkingSlotDetailsQuery(id));

        return TypedResults.Ok(result);
    }
    
    private static async Task<Results<Created<ParkingSlotDto>, BadRequest<string>>> AddParkingSlot(ISender sender,
        [FromQuery] string Name,
        int capacity,
        string description)
    {
        var result = await sender.Send(new CreateParkingSlotCommand { Title = Name, Capacity = capacity, Description = description });

        return TypedResults.Created(new Uri($"/api/ParkingSlots/{result.Id}", UriKind.Relative), result);
    }
    

    private static async Task<Results<Ok<ParkingSlotDto>, NotFound, BadRequest<string>>> EditParkingSlot(ISender sender,
        [FromRoute] int id,
        [FromBody] EditParkingSlotCommand command)
    {
        if (command.Id != id) return TypedResults.BadRequest("Id mismatch");

        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<ParkingSlotDto>, NotFound, BadRequest<string>>> DeleteParkingSlot(
        ISender sender, [FromRoute] int id)
    {
        var response = await sender.Send(new DeleteParkingSlotCommand(id));

        return TypedResults.Ok(response);
    }

    #endregion

    #region CarOperations

    private static async Task<Results<Ok<ParkingSlotDto>, BadRequest<string>>> AddCarToSlot(ISender sender,
        [FromRoute] int id,
        Guid carId)
    {
        var result = await sender.Send(new AddCarToSlotCommand { SlotId = id, CarId = carId });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<ParkingSlotDto>, NotFound, BadRequest<string>>> RemoveCarFromSlot(
        ISender sender,
        [FromRoute] Guid carId)
    {
        var result = await sender.Send(new RemoveCarFromSlotCommand(carId));

        return TypedResults.Ok(result);
    }

    #endregion
}
