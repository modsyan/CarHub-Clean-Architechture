using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Documents.Commands;

public record DeleteDocumentTrashPermanentlyCommand(Guid Id) : IRequest<bool>
{
}

public class DeleteDocumentTrashPermanentlyCommandValidator : AbstractValidator<DeleteDocumentTrashPermanentlyCommand>
{
    public DeleteDocumentTrashPermanentlyCommandValidator(IApplicationDbContext context,
        IStringLocalizer<DeleteDocumentTrashPermanentlyCommandValidator> localizer)
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(x => x.Id)
            .MustAsync(async (id, cancellationToken) =>
                await context.Documents.IgnoreQueryFilters()
                    .AnyAsync(d => d.Id == id && d.IsDeleted, cancellationToken))
            .WithMessage(localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }
}

public class DeleteDocumentTrashPermanentlyCommandHandler(
    IApplicationDbContext context,
    IFileService fileService)
    : IRequestHandler<DeleteDocumentTrashPermanentlyCommand, bool>
{
    public async Task<bool> Handle(DeleteDocumentTrashPermanentlyCommand request, CancellationToken cancellationToken)
    {
        var document = await context
                           .Documents
                           .IgnoreQueryFilters()
                           .Where(d => d.Id == request.Id && d.IsDeleted)
                           .Include(d => d.File)
                           .FirstAsync(cancellationToken) ??
                       throw new NotFoundException(nameof(Document), request.Id.ToString());

        if (document.File != null)
            await fileService.DeleteFileAsync(document.File, cancellationToken);

        context.Documents.Remove(document);

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
