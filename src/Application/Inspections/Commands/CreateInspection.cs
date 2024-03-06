using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Inspections.Commands;

public class InspectionItem
{
    public string Title { get; set; } = string.Empty;
    public IFormFile File { get; set; } = null!;

    // public string FileName { get; set; } = string.Empty;
    //
    // public byte[] File { get; set; } = Array.Empty<byte>();
    //
    // public string MimeType { get; set; } = string.Empty;
}

/** Todo: switch to byte[] and string for file and mime type
 *
 *      public List<InspectionItem> InspectionItems { get; set; } = [];
 */
/** Todo: using 2 lists where one is for IFormFile and the other is for Title if continue with IFormFileCollection in the command
 *
 *      public List<IFormFile> Files { get; set; } = [];
 *      public List<string> Titles { get; set; } = [];
 */

// Todo: use now for upload one file and title ony-by-one
public record CreateInspectionCommand : IRequest<CarDto>
{
    public Guid CarId { get; set; }

    public List<InspectionItem> InspectionItems { get; set; } = [];
}

public class CreateInspectionCommandValidator : AbstractValidator<CreateInspectionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<CreateInspectionCommandValidator> _stringLocalizer;
    private readonly ICarService _carService;

    public CreateInspectionCommandValidator(IApplicationDbContext context,
        IStringLocalizer<CreateInspectionCommandValidator> stringLocalizer, ICarService carService)
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

        RuleFor(x => x.InspectionItems)
            .NotEmpty()
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(x => x.InspectionItems)
            .Must(x => x.Count <= 5)
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_MAX_FILES, 5]);

        // RuleFor(x => x.InspectionItems)
        //     .Must(x => x.All(i => i.File.Length <= 5 * 1024 * 1024))
        //     .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_MAX_FILE_SIZE, 5]);

        RuleFor(x => x.InspectionItems)
            .Must(x => x.All(i => string.IsNullOrWhiteSpace(i.Title) || i.Title.Length <= 200))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_MAX_LENGTH, 200]);

        RuleFor(x => x.InspectionItems)
            .Must(x => x.Any(i => !string.IsNullOrWhiteSpace(i.Title) || i.File.Length > 0))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_EMPTY_FILE_WITH_TITLE]);

        // RuleFor(x => x.InspectionItems)
        //     .Must(x => x.All(i => i.File.ContentType is "image/jpeg" or "image/png" or "image/jpg" or "image/webp"))
        //     .WithMessage(_stringLocalizer[SharedResourcesKeys.ERR_INVALID_FILE_EXTENSION, "jpeg, jpg, webp, png"]);
    }
}

public class CreateInspectionCommandHandler(
    IApplicationDbContext context,
    IFileService fileService,
    IMapper mapper,
    ICarService carService)
    : IRequestHandler<CreateInspectionCommand, CarDto>
{
    public async Task<CarDto> Handle(CreateInspectionCommand request, CancellationToken cancellationToken)
    {
        var car = await carService.GetCarDetails(request.CarId, cancellationToken);

        Guard.Against.NotFound(request.CarId, car);

        foreach (var item in request.InspectionItems)
        {
            var file = await fileService.SaveToDiskAsync(item.File, cancellationToken);
            await context.Inspections.AddAsync(
                new Inspection { CarId = request.CarId, Text = item.Title, File = file }, cancellationToken);
        }

        // var file = await _fileService.SaveToDiskAsync(request.File, cancellationToken);

        // car.Inspections.Add(new Inspection { Text = request.Title, File = file, });

        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CarDto>(car);
    }
}
