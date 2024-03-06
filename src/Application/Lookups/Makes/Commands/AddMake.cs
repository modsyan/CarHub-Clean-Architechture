using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Lookups.Makers.Commands;

public record CreateMakerModelsCommand : IRequest<ModelDto>
{
}

public class CreateMakerModelsCommandValidator : AbstractValidator<CreateMakerModelsCommand>
{
    public CreateMakerModelsCommandValidator()
    {
    }
}

public class CreateMakerModelsCommandHandler : IRequestHandler<CreateMakerModelsCommand, ModelDto>
{
    private readonly IApplicationDbContext _context;

    public CreateMakerModelsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<ModelDto> Handle(CreateMakerModelsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
