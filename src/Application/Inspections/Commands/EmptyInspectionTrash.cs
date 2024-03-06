using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands.EmptyInspectionTrash;

public record EmptyInspectionTrashCommand : IRequest<bool>
{
    public Guid CarId { get; init; }
}

public class EmptyInspectionTrashCommandValidator : AbstractValidator<EmptyInspectionTrashCommand>
{
    public EmptyInspectionTrashCommandValidator(
        ICarService carService,
        IStringLocalizer<EmptyInspectionTrashCommandValidator> localizer
    )
    {
        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(async (id, cancellationToken) => await carService.Exists(id, cancellationToken))
            .WithMessage(localizer[SharedResourcesKeys.ERROR_CAR_NOT_FOUND]);
    }
}

public class EmptyInspectionTrashCommandHandler(IApplicationDbContext context)
    : IRequestHandler<EmptyInspectionTrashCommand, bool>
{
    public async Task<bool> Handle(EmptyInspectionTrashCommand request, CancellationToken cancellationToken)
    {
        var query = await context.Inspections
            .IgnoreQueryFilters()
            .Where(d =>
                d.IsDeleted && d.CarId == request.CarId
            )
            .ToListAsync(cancellationToken);

        if (query is { Count: 0 })
            throw new NotFoundException(nameof(Inspection), request.CarId.ToString());

        context.Inspections.RemoveRange(query);

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
