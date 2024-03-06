using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands.DeleteInspectionTrashPermanently;

public record DeleteInspectionTrashPermanentlyCommand(Guid Id) : IRequest<bool>
{
}

public class
    DeleteInspectionTrashPermanentlyCommandValidator : AbstractValidator<DeleteInspectionTrashPermanentlyCommand>
{
    public DeleteInspectionTrashPermanentlyCommandValidator(IApplicationDbContext context,
        IStringLocalizer<DeleteInspectionTrashPermanentlyCommandValidator> localizer)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
                await context.Inspections.IgnoreQueryFilters()
                    .AnyAsync(d => d.Id == id && d.IsDeleted, cancellationToken))
            .WithMessage(localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }
}

public class DeleteInspectionTrashPermanentlyCommandHandler(
    IApplicationDbContext context,
    IFileService fileService)
    : IRequestHandler<DeleteInspectionTrashPermanentlyCommand, bool>
{
    public async Task<bool> Handle(DeleteInspectionTrashPermanentlyCommand request, CancellationToken cancellationToken)
    {
        var inspection = await context
                             .Inspections
                             .IgnoreQueryFilters()
                             .Include(d => d.File)
                             .FirstOrDefaultAsync(d => d.Id == request.Id && d.IsDeleted, cancellationToken) ??
                         throw new NotFoundException(nameof(Inspection), request.Id.ToString());

        if (inspection.File != null)
            await fileService.DeleteFileAsync(inspection.File, cancellationToken);

        context.Inspections.Remove(inspection);
        
        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
