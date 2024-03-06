using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands.RestoreInspectionFromTrash;

public record RestoreInspectionFromTrashCommand(Guid Id) : IRequest<bool>
{
}

public class RestoreInspectionFromTrashCommandValidator : AbstractValidator<RestoreInspectionFromTrashCommand>
{
    public RestoreInspectionFromTrashCommandValidator(
        IStringLocalizer<RestoreInspectionFromTrashCommandValidator> localizer)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class RestoreInspectionFromTrashCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RestoreInspectionFromTrashCommand, bool>
{
    public async Task<bool> Handle(RestoreInspectionFromTrashCommand request, CancellationToken cancellationToken)
    {
        var inspection = await context
                             .Inspections
                             .IgnoreQueryFilters()
                             .FirstOrDefaultAsync(d => d.Id == request.Id && d.IsDeleted, cancellationToken) ??
                         throw new NotFoundException(nameof(Inspection), request.Id.ToString());

        inspection.IsDeleted = false;

        return await context.SaveChangesAsync(cancellationToken) > 0;   
    }
}
