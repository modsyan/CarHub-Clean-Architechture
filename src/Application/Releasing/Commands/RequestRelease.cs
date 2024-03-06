using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Releasing.Commands;

public record RequestReleaseCommand : IRequest<CarDto>
{
    public Guid CarId { get; init; }
    public DateTime ReleaseDate { get; init; }
    public string Notes { get; init; } = null!;

    public List<IFormFile> Documents { get; init; } = [];
}

public class RequestReleaseCommandValidator : AbstractValidator<RequestReleaseCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<RequestReleaseCommandValidator> _localizer;
    private readonly ICarService _carService;

    public RequestReleaseCommandValidator(IApplicationDbContext context,
        IStringLocalizer<RequestReleaseCommandValidator> localizer, ICarService carService)
    {
        _context = context;
        _localizer = localizer;
        _carService = carService;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(r => r.CarId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(CarExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        RuleFor(r => r.ReleaseDate)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(r => r.Notes)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }

    private async Task<bool> CarExists(Guid carId, CancellationToken cancellationToken)
    {
        return await _context.Cars.AnyAsync(c => c.Id == carId, cancellationToken);
    }
}

public class RequestReleaseCommandHandler : IRequestHandler<RequestReleaseCommand, CarDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<RequestReleaseCommandHandler> _localizer;
    private readonly ICarService _carService;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public RequestReleaseCommandHandler(IApplicationDbContext context,
        IStringLocalizer<RequestReleaseCommandHandler> localizer, ICarService carService, IFileService fileService,
        IMapper mapper)
    {
        _context = context;
        _localizer = localizer;
        _carService = carService;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<CarDto> Handle(RequestReleaseCommand request, CancellationToken cancellationToken)
    {
        var car = await _carService.GetCarDetails(request.CarId, cancellationToken) ??
                  throw new NotFoundException(nameof(Car), request.CarId.ToString());

        var release = new ReleaseRequest(car.Id, request.ReleaseDate, request.Notes);

        if (request.Documents.Count != 0)
            foreach (var document in request.Documents)
            {
                var file = await _fileService.SaveToDiskAsync(document, cancellationToken);

                release.Documents.Add(new ReleaseDocument { CarId = car.Id, Image = file });
            }

        _context.ReleaseRequests.Add(release);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarDto>(car);
    }
}
