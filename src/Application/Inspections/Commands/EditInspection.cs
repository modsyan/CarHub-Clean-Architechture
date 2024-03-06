using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands;

public record EditInspectionCommand : IRequest<CarDto>
{
    public Guid InspectionId { get; set; }
    public string? Title { get; set; }
    public IFormFile? File { get; set; }
}

public class EditInspectionCommandValidator : AbstractValidator<EditInspectionCommand>
{
    private readonly IStringLocalizer<EditInspectionCommandValidator> _localizer;

    public EditInspectionCommandValidator(IStringLocalizer<EditInspectionCommandValidator> localizer)
    {
        _localizer = localizer;
        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.InspectionId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(x => x.Title)
            .Must((cmd, title) => title is not null && title.Length <= 200 || cmd.File is not null)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);


        RuleFor(x => x.File)
            .Must(file => file is null || file.Length <= 5 * 1024 * 1024)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_FILE_SIZE, "5M"]);

        // RuleFor(x => x.File)
        //     .Must(file =>
        //         file is null || file.ContentType is "image/jpeg" or "image/png" or "image/jpg" or "image/webp")
        //     .WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_FILE_EXTENSION, "jpeg, jpg, webp, png"]);
    }
}

public class EditInspectionCommandHandler(
    IApplicationDbContext context,
    IFileService fileService,
    ICarService carService,
    IMapper mapper)
    : IRequestHandler<EditInspectionCommand, CarDto>
{
    public async Task<CarDto> Handle(EditInspectionCommand request, CancellationToken cancellationToken)
    {
        var inspection = await context.Inspections
                             .FirstOrDefaultAsync(d => d.Id == request.InspectionId, cancellationToken) ??
                         throw new NotFoundException(nameof(Inspection), request.InspectionId.ToString());


        if (request.File != null)
        {
            if (inspection.File != null)
            {
                await fileService.DeleteFileAsync(inspection.File, cancellationToken);

                context.UploadedFiles.Remove(inspection.File);
            }

            var file = await fileService.SaveToDiskAsync(request.File, cancellationToken);

            context.UploadedFiles.Add(file);

            inspection.File = file;
        }

        if (request.Title != null) inspection.Text = request.Title;

        await context.SaveChangesAsync(cancellationToken);

        var car = await carService.GetCarDetails(inspection.CarId, cancellationToken);
        
        return mapper.Map<CarDto>(car);
    }
}
