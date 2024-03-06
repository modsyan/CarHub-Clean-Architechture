using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Lookups.Makers.Commands;

public record UpdateMakerModelsCommand : IRequest<MakeDto>
{
}

public class UpdateMakerModelsCommandValidator : AbstractValidator<UpdateMakerModelsCommand>
{
    public UpdateMakerModelsCommandValidator()
    {
    }
}

public class UpdateMakerModelsCommandHandler : IRequestHandler<UpdateMakerModelsCommand, MakeDto>
{
    private readonly IApplicationDbContext _context;

    public UpdateMakerModelsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<MakeDto> Handle(UpdateMakerModelsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
