using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands.RestoreDocumentFromTrash;

public record RestoreDocumentFromTrashCommand(Guid Id) : IRequest<bool>
{
}

public class RestoreDocumentFromTrashCommandValidator : AbstractValidator<RestoreDocumentFromTrashCommand>
{
    public RestoreDocumentFromTrashCommandValidator(
        IStringLocalizer<RestoreDocumentFromTrashCommandValidator> localizer)
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class RestoreDocumentFromTrashCommandHandler(IApplicationDbContext context)
    : IRequestHandler<RestoreDocumentFromTrashCommand, bool>
{
    private readonly IApplicationDbContext _context = context;

    public async Task<bool> Handle(RestoreDocumentFromTrashCommand request, CancellationToken cancellationToken)
    {
        var document = await _context
                           .Documents
                            .IgnoreQueryFilters()
                           .FirstOrDefaultAsync(d => d.Id == request.Id && d.IsDeleted, cancellationToken) ??
                       throw new NotFoundException(nameof(Document), request.Id.ToString());

        document.IsDeleted = false;

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
