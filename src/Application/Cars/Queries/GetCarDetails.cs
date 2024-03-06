using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Cars.Queries;

public record GetCarDetailsQuery(Guid Id) : IRequest<CarDto>;

public class GetCarDetailsQueryValidator : AbstractValidator<GetCarDetailsQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetCarDetailsQueryValidator> _localizer;

    public GetCarDetailsQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetCarDetailsQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(IsCarExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }

    private async Task<bool> IsCarExists(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Cars.AnyAsync(l => l.Id == id, cancellationToken);
    }
}

public class GetCarDetailsQueryHandler(
    IStringLocalizer<GetCarDetailsQueryHandler> localizer,
    IMapper mapper,
    IIdentityService identityService,
    ICarService carService)
    : IRequestHandler<GetCarDetailsQuery, CarDto>
{
    public async Task<CarDto> Handle(GetCarDetailsQuery request, CancellationToken cancellationToken)
    {
        var car = await carService.GetCarDetails(request.Id, cancellationToken)
                  ?? throw new NotFoundException(nameof(Car), localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        var result = mapper.Map<CarDto>(car);

        if (car.UserId.ToString() == "00000000-0000-0000-0000-000000000000")
            return result;

        var userDetails = await identityService.GetUserDetailsAsync(car.UserId);

        if (userDetails is null)
            throw new NotFoundException(nameof(userDetails), localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        result.OwnerDetails = userDetails;

        return result;
    }
}
