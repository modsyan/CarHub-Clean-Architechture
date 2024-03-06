using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Documents.Commands;

public record DeleteDocumentCommand(List<Guid> DocumentIds) : IRequest<bool>
{
}

public class DeleteDocumentCommandValidator : AbstractValidator<DeleteDocumentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<DeleteDocumentCommandValidator> _stringLocalizer;
    private readonly ICarService _carService;

    public DeleteDocumentCommandValidator(IApplicationDbContext context,
        IStringLocalizer<DeleteDocumentCommandValidator> stringLocalizer, ICarService carService)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _carService = carService;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.DocumentIds)
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class DeleteDocumentCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteDocumentCommand, bool>
{
    public async Task<bool> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
    {
        var documents = await context.Documents
            .Where(d => request.DocumentIds.Contains(d.Id))
            .ToListAsync(cancellationToken);

        if (documents.Count != request.DocumentIds.Count)
            throw new NotFoundException(nameof(Document), string.Join(", ", request.DocumentIds));

        foreach (var document in documents) document.IsDeleted = true;

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
