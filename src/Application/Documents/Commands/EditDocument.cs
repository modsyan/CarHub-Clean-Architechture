using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Mac.CarHub.Application.Documents.Commands;

public record EditDocumentCommand : IRequest<CarDto>
{
    public Guid DocumentId { get; init; }

    public string? Title { get; init; } = null!;

    public IFormFile? File { get; init; } = null!;
}

public class EditDocumentCommandValidator : AbstractValidator<EditDocumentCommand>
{
    private readonly IStringLocalizer<EditDocumentCommandValidator> _localizer;

    public EditDocumentCommandValidator(IStringLocalizer<EditDocumentCommandValidator> localizer)
    {
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.DocumentId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(x => x.Title)
            .Must((cmd, title) => cmd.Title is not null && cmd.Title.Length <= 200 || cmd.File != null)
            .WithMessage(SharedResourcesKeys.ERR_REQUIRED);

        RuleFor(x => x.File)
            .Must(file => file is null || file.Length <= 5 * 1024 * 1024)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_FILE_SIZE, "5M"]);

        // RuleFor(x => x.File)
        //     .Must(file =>
        //         file is null || file.ContentType is "image/jpeg" or "image/png" or "image/jpg" or "image/webp")
        //     .WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_FILE_EXTENSION, "jpeg, jpg, webp, png"]);
    }
}

public class EditDocumentCommandHandler(
    IApplicationDbContext context,
    IFileService fileService,
    ICarService carService,
    IMapper mapper)
    : IRequestHandler<EditDocumentCommand, CarDto>
{
    public async Task<CarDto> Handle(EditDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = await context.Documents
                           .FirstOrDefaultAsync(d => d.Id == request.DocumentId, cancellationToken) ??
                       throw new NotFoundException(nameof(Document), request.DocumentId.ToString());

        if (request.File != null)
        {
            if (document.File != null)
            {
                await fileService.DeleteFileAsync(document.File, cancellationToken);
            
                context.UploadedFiles.Remove(document.File);
                
            }
            
            var file = await fileService.SaveToDiskAsync(request.File, cancellationToken);
            
            context.UploadedFiles.Add(file);
            
            document.File = file;
        }

        if (request.Title is not null) document.Title = request.Title;

        await context.SaveChangesAsync(cancellationToken);

        var car = await carService.GetCarDetails(document.CarId, cancellationToken);
        
        return mapper.Map<CarDto>(car);
    }
}
