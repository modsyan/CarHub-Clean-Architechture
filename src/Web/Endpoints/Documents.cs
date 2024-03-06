using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Documents.Commands;
using Mac.CarHub.Application.Documents.Queries;
using Mac.CarHub.Application.Inspections.Commands.EmptyDocumentTrash;
using Mac.CarHub.Application.Inspections.Commands.RestoreDocumentFromTrash;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Documents : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapPost(CreateDocument)
            .MapPut(EditDocument, "{id:guid}")
            .MapDelete(DeleteDocument, "{id:guid}");

        app.MapGroup(this)
            .MapPost(CreateManyDocuments, "List")
            .MapDelete(DeleteManyDocuments, "List");

        app.MapGroup(this)
            .MapGet(GetDocumentsFromTrash, "Trash")
            .MapPost(RestoreDocumentFromTrash, "Trash/Restore/{id:guid}")
            .MapDelete(EmptyDocumentTrash, "Trash/Delete")
            .MapDelete(DeleteDocumentPermanently, "Trash/Delete/{id:guid}");
    }

    private static async Task<Results<Created<CarDto>, BadRequest<string>>> CreateDocument(ISender sender,
        [FromQuery] Guid carId,
        [FromQuery] string title,
        [FromForm] IFormFile files
    )
    {
        var item = new DocumentItem { Title = title, File = files };

        var result = await sender.Send(new CreateDocumentCommand { CarId = carId, Items = [item] });

        return TypedResults.Created(new Uri($"/api/Orders/documents/{result.Id}", UriKind.Relative), result);
    }

    private static async Task<Results<Created<CarDto>, BadRequest<string>>> CreateManyDocuments(ISender sender,
        [FromForm] Guid carId,
        [FromForm] List<string> titles,
        [FromForm] IFormFileCollection files)
    {
        var items = files.Select((f, i) => new DocumentItem { Title = titles[i], File = f }).ToList();

        var result = await sender.Send(new CreateDocumentCommand { CarId = carId, Items = items });

        return TypedResults.Created(new Uri($"/api/Orders/documents/{result.Id}", UriKind.Relative), result);
    }


    private static async Task<Results<Ok<CarDto>, NotFound, BadRequest<string>>> EditDocument(ISender sender,
        [FromRoute] Guid id,
        [FromQuery] string? title,
        [FromForm] IFormFile? file)
    {
        if (file is null && title is null)
        {
            return TypedResults.BadRequest("Title or file is required");
        }
        
        var result = await sender.Send(new EditDocumentCommand { DocumentId= id, File = file, Title = title });


        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> DeleteDocument(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new DeleteDocumentCommand([id]));

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> DeleteManyDocuments(ISender sender,
        [FromForm] List<Guid> documentIds)
    {
        var result = await sender.Send(new DeleteDocumentCommand(documentIds));

        return TypedResults.Ok(result);
    }

    #region Trash

    private static async Task<Results<Ok<PaginatedList<DocumentDto>>, BadRequest<string>>> GetDocumentsFromTrash(
        ISender sender,
        [FromQuery] Guid? carId)
    {
        var result = await sender.Send(new GetDocumentTrashQuery { CarId = carId });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> RestoreDocumentFromTrash(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new RestoreDocumentFromTrashCommand(id));

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> EmptyDocumentTrash(ISender sender,
        [FromQuery] Guid carId)
    {
        var result = await sender.Send(new EmptyDocumentTrashCommand { CarId = carId });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<bool>, BadRequest<string>>> DeleteDocumentPermanently(ISender sender,
        [FromRoute] Guid id)
    {
        var result = await sender.Send(new DeleteDocumentTrashPermanentlyCommand(id));

        return TypedResults.Ok(result);
    }

    #endregion
}
