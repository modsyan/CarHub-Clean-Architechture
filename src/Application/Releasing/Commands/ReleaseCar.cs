using Mac.CarHub.Application.Common.Exceptions;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Releasing.Commands;

public record ReleaseCarCommand : IRequest<ReleaseDto>
{
    public Guid Id { get; init; }
    public DateTime? ReleaseDate { get; init; }
    public List<IFormFile>? Documents { get; set; } = [];
}

public class ReleaseCarCommandValidator : AbstractValidator<ReleaseCarCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<ReleaseCarCommandValidator> _localizer;

    public ReleaseCarCommandValidator(IApplicationDbContext context,
        IStringLocalizer<ReleaseCarCommandValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(r => r.Id)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(CarExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }

    private async Task<bool> CarExists(Guid carId, CancellationToken cancellationToken)
    {
        return await _context.Cars.AnyAsync(c => c.Id == carId, cancellationToken);
    }
}

public class ReleaseCarCommandHandler : IRequestHandler<ReleaseCarCommand, ReleaseDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<ReleaseCarCommandHandler> _localizer;
    private readonly IMapper _mapper;
    private readonly ICarService _carService;
    private readonly IFileService _fileService;

    public ReleaseCarCommandHandler(IApplicationDbContext context, IStringLocalizer<ReleaseCarCommandHandler> localizer,
        IMapper mapper, ICarService carService, IFileService fileService)
    {
        _context = context;
        _localizer = localizer;
        _mapper = mapper;
        _carService = carService;
        _fileService = fileService;
    }

    public async Task<ReleaseDto> Handle(ReleaseCarCommand request, CancellationToken cancellationToken)
    {
        var car = await _carService.GetCarDetails(request.Id, cancellationToken) ??
                  throw new NotFoundException(nameof(Car), request.Id.ToString());

        if (car.Release is not null)
        {
            throw new InvalidOperationException(_localizer[SharedResourcesKeys.ERR_ALREADY_RELEASED]);
        }

        var release = new Release { Car = car, ReleaseDate = request.ReleaseDate ?? DateTime.UtcNow };

        if (request.Documents is null or { Count: <= 0 })
        {
            return _mapper.Map<ReleaseDto>(release);
        }

        foreach (var document in request.Documents)
        {
            var image = await _fileService.SaveToDiskAsync(document, cancellationToken);

            release.Documents.Add(new ReleaseDocument { Image = image, CarId = car.Id });
        }

        await _context.Releases.AddAsync(release, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ReleaseDto>(release);
    }
}
