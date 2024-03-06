using System.ComponentModel;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Documents.Commands;

public class DocumentItem
{
    public string Title { get; set; } = string.Empty;
    public IFormFile File { get; set; } = null!;
}

public record CreateDocumentCommand : IRequest<CarDto>
{
    public Guid CarId { get; init; }

    public List<DocumentItem> Items { get; set; } = [];
}

public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICarService _carService;

    private readonly IStringLocalizer<CreateDocumentCommandValidator> _stringLocalizer;

    public CreateDocumentCommandValidator(
        IApplicationDbContext context,
        IStringLocalizer<CreateDocumentCommandValidator> stringLocalizer, ICarService carService)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _carService = carService;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.CarId)
            .NotEmpty()
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(x => x.CarId)
            .MustAsync(async (id, token) => await _carService.Exists(id, token))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_NOT_FOUND, "Car"]);
        
        RuleFor(x => x.Items)
            .Must(x => x.Count <= 5)
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_MAX_FILES, 5]);

        RuleFor(x => x.Items)
            .Must(x => x.All(f => f.File is null || f.File.Length <= 5 * 1024 * 1024))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_MAX_FILE_SIZE, 5]);

        RuleFor(x => x.Items)
            .Must(x => x.All(f => string.IsNullOrWhiteSpace(f.Title) || f.Title.Length <= 200))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_MAX_LENGTH, 200]);
        
        RuleFor(x => x.Items)
            .Must(x => x.All(f => !string.IsNullOrWhiteSpace(f.Title) || f.File.Length > 0))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_EMPTY_FILE_WITH_TITLE]);

        // RuleFor(x => x.Items)
        //     .Must(x => x.All(i => i.File?.ContentType is "image/jpeg" or "image/jpg" or "image/webp" or "image/png"))
        //     .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_INVALID_FILE_EXTENSION, "jpeg, jpg, webp, png"]);
    }
}

public class CreateDocumentCommandHandler(
    IApplicationDbContext context,
    IFileService fileService,
    IMapper mapper,
    ICarService carService
) : IRequestHandler<CreateDocumentCommand, CarDto>
{
    public async Task<CarDto> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        var car = await carService.GetCarDetails(request.CarId, cancellationToken);

        Guard.Against.NotFound(request.CarId, car);

        foreach (var item in request.Items)
        {
            var file = await fileService.SaveToDiskAsync(item.File, cancellationToken);
            await context.Documents.AddAsync(new Document(item.Title, request.CarId, file), cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CarDto>(car);
    }
}
