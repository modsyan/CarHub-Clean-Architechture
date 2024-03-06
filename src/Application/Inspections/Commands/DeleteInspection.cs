using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands;

public record DeleteInspectionCommand(List<Guid> InspectionIds) : IRequest<bool>
{
}

public class DeleteInspectionCommandValidator : AbstractValidator<DeleteInspectionCommand>
{
    private readonly IStringLocalizer<DeleteInspectionCommandValidator> _stringLocalizer;

    public DeleteInspectionCommandValidator(IApplicationDbContext context,
        IStringLocalizer<DeleteInspectionCommandValidator> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {

        RuleFor(x => x.InspectionIds)
            .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_REQUIRED]);
    }
}

public class DeleteInspectionCommandHandler(IApplicationDbContext context)
    : IRequestHandler<DeleteInspectionCommand, bool>
{
    public async Task<bool> Handle(DeleteInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspections = await context
            .Inspections
            .Where(i => request.InspectionIds.Contains(i.Id))
            .ToListAsync(cancellationToken);

        if (inspections.Count != request.InspectionIds.Count)
            throw new NotFoundException(nameof(Inspection), string.Join(", ", request.InspectionIds));

        foreach (var inspection in inspections) inspection.IsDeleted = true;

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}
