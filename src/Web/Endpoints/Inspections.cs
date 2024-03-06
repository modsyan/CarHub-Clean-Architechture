using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Inspections.Commands;
using Mac.CarHub.Application.Inspections.Commands.DeleteInspectionTrashPermanently;
using Mac.CarHub.Application.Inspections.Commands.EmptyInspectionTrash;
using Mac.CarHub.Application.Inspections.Commands.RestoreInspectionFromTrash;
using Mac.CarHub.Application.Inspections.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Inspections : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateInspection)
            .MapPut(EditInspection, "{id:guid}")
            .MapDelete(DeleteInspection, "{id:guid}");

        app.MapGroup(this)
            .MapPost(CreateManyInspections, "List")
            .MapDelete(DeleteManyInspections, "List");

        app.MapGroup(this)
            .MapGet(GetInspectionsFromTrash, "Trash")
            .MapPost(RestoreInspectionsFromTrash, "Trash/Restore/{id:guid}")
            .MapDelete(EmptyInspectionTrash, "Trash/Delete")
            .MapDelete(DeleteInspectionPermanently, "Trash/Delete/{id:guid}");
    }


    private static async Task<Results<Created<CarDto>, BadRequest<string>>> CreateInspection(ISender sender,
        [FromQuery] Guid carId,
        [FromQuery] string title,
        [FromForm] IFormFile file)
    {
        var item = new InspectionItem { File = file, Title = title };

        var result = await sender.Send(new CreateInspectionCommand { CarId = carId, InspectionItems = [item] });

        return TypedResults.Created($"/api/inspections/{result.Id}", result);
    }

    private static async Task<Results<Created<CarDto>, BadRequest<string>>> CreateManyInspections(ISender sender,
        [FromQuery] Guid carId,
        [FromForm] List<string> titles,
        [FromForm] IFormFileCollection files)
    {
        var inspectionItems = files.Select((f, i) =>
            new InspectionItem { Title = titles[i], File = f }).ToList();

        var result =
            await sender.Send(new CreateInspectionCommand { CarId = carId, InspectionItems = inspectionItems });

        return TypedResults.Created($"/api/inspections/{result.Id}", result);
    }

    private static async Task<Results<Ok<CarDto>, NotFound, BadRequest<string>>> EditInspection(ISender sender,
        [FromRoute] Guid id,
        [FromQuery] string? title,
        [FromForm] IFormFile? file
    )
    {
        if (title is null && file is null)
        {
            return TypedResults.BadRequest("Title or file is required");
        }

        var result = await sender.Send(new EditInspectionCommand { InspectionId = id, Title = title, File = file });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> DeleteInspection(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new DeleteInspectionCommand([id]));

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> DeleteManyInspections(ISender sender,
        [FromForm] List<Guid> inspectionIds)
    {
        var result = await sender.Send(new DeleteInspectionCommand(inspectionIds));

        return TypedResults.Ok(result);
    }

    # region Trash

    private static async Task<Results<Ok<PaginatedList<InspectionDto>>, BadRequest<string>>> GetInspectionsFromTrash(
        ISender sender,
        [FromQuery] Guid? carId)
    {
        var result = await sender.Send(new GetInspectionTrashQuery { CarId = carId });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> RestoreInspectionsFromTrash(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new RestoreInspectionFromTrashCommand(id));

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> EmptyInspectionTrash(ISender sender,
        [FromQuery] Guid carId)
    {
        var result = await sender.Send(new EmptyInspectionTrashCommand { CarId = carId });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> DeleteInspectionPermanently(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new DeleteInspectionTrashPermanentlyCommand(id));

        return TypedResults.Ok(result);
    }

    # endregion
}
