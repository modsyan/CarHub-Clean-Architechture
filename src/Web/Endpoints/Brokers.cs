using Mac.CarHub.Application.Brokers.Commands;
using Mac.CarHub.Application.Brokers.Queries;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Mac.CarHub.Web.Endpoints;

public class Brokers : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetBrokers)
            .MapGet(GetBroker, "{id:guid}")
            .MapPost(CreateBroker)
            .MapPut(EditBroker, "{id:guid}")
            .MapDelete(DeleteBroker, "{id:guid}");

        app.MapGroup(this)
            .MapGet("Test",
                async (IWebHostEnvironment env, IAvatarGeneratorService avatarGeneratorService) =>
                {
                    // return await avatarGeneratorService.AvatarsWithInitialsFromNames("Bassil", "Abo");
                    // return await avatarGeneratorService.GetBrokerAvatar();

                    // var file = await avatarGeneratorService.GetRandomAvatar();
                    var file = await avatarGeneratorService.GetRandomAvatarMenOnly();

                    if (file == null) return null;

                    return $"https://localhost:3001{file.FilePath}";
                });
    }

    private static async Task<Results<Ok<BrokerDto>, NotFound>> GetBroker(ISender sender, [FromRoute] Guid id)
    {
        var result = await sender.Send(new GetBrokerQuery(id));

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<BrokerVm>, BadRequest<string>>> GetBrokers(ISender sender,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string searchString = ""
    )
    {
        var result = await sender.Send(new GetBrokersQuery
        {
            PageNumber = pageNumber, PageSize = pageSize, SearchString = searchString
        });

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Created<BrokerDto>, BadRequest>> CreateBroker(ISender sender,
        [AsParameters] CreateBrokerCommand command)
    {
        var result = await sender.Send(command);

        return TypedResults.Created(new Uri($"/api/Brokers/{result.Id}", UriKind.Relative), result);
    }

    private static async Task<Results<Ok<BrokerDto>, NotFound, BadRequest<string>>> EditBroker(ISender sender,
        [FromRoute] Guid id,
        [FromBody] EditBrokerCommand command)
    {
        if (command.Id != id) return TypedResults.BadRequest("Id mismatch");

        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<BrokerDto>, NotFound>> DeleteBroker(ISender sender, [FromRoute] Guid id)
    {
        var result = await sender.Send(new DeleteBrokerCommand(id));

        return TypedResults.Ok(result);
    }
}
