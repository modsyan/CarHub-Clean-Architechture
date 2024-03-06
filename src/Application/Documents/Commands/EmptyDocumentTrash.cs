using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands.EmptyDocumentTrash;

public record EmptyDocumentTrashCommand : IRequest<bool>
{
    public Guid CarId { get; init; }
}

public class EmptyDocumentTrashCommandValidator : AbstractValidator<EmptyDocumentTrashCommand>
{
    public EmptyDocumentTrashCommandValidator(
        ICarService carService,
        IStringLocalizer<EmptyDocumentTrashCommandValidator> localizer
    )
    {
        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(async (id, cancellationToken) => await carService.Exists(id, cancellationToken))
            .WithMessage(localizer[SharedResourcesKeys.ERROR_CAR_NOT_FOUND]);
    }
}

public class EmptyDocumentTrashCommandHandler(IApplicationDbContext context)
    : IRequestHandler<EmptyDocumentTrashCommand, bool>
{
    public async Task<bool> Handle(EmptyDocumentTrashCommand request, CancellationToken cancellationToken)
    {
        var query = await context.Documents
            .IgnoreQueryFilters()
            .Where(d =>
                d.IsDeleted &&
                d.CarId == request.CarId
            )
            .ToListAsync(cancellationToken);

        if (query is { Count: 0 }) 
            throw new NotFoundException(nameof(Document), request.CarId.ToString());

        context.Documents.RemoveRange(query);

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
