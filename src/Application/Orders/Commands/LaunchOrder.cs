using Mac.CarHub.Application.Common.Exceptions;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Application.Models;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Orders.Commands;

public record LaunchOrderCommand : IRequest<CarDto>
{
    public int ModelId { get; set; }
    public int Year { get; set; }
    public int ColorId { get; set; }
    public bool IsBroker { get; set; }
    public string UserFullName { get; set; } = null!;
    public string UserNationalityId { get; set; } = null!;
    public int ReleasedAfterInMonths { get; set; }
}

public class LaunchOrderCommandValidator : AbstractValidator<LaunchOrderCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<LaunchOrderCommandValidator> _localizer;

    public LaunchOrderCommandValidator(IApplicationDbContext context,
        IStringLocalizer<LaunchOrderCommandValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.ModelId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .GreaterThanOrEqualTo(0).WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_ID])
            .MustAsync(IsModelExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        RuleFor(v => v.Year)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .InclusiveBetween(1900, 2100).WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_YEAR]);

        RuleFor(v => v.ColorId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .GreaterThanOrEqualTo(0).WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_ID])
            .MustAsync(IsColorExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);

        RuleFor(v => v.UserFullName)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(v => v.UserNationalityId)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(v => v.ReleasedAfterInMonths)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .InclusiveBetween(1, 12).WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_MONTHS]);
    }

    private async Task<bool> IsModelExists(int id, CancellationToken cancellationToken)
    {
        return await _context.Models.AnyAsync(l => l.Id == id, cancellationToken);
    }

    private async Task<bool> IsColorExists(int id, CancellationToken cancellationToken)
    {
        return await _context.Colors.AnyAsync(l => l.Id == id, cancellationToken);
    }
}

public class LaunchOrderCommandHandler : IRequestHandler<LaunchOrderCommand, CarDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<LaunchOrderCommandHandler> _localizer;
    private readonly IIdentityService _identityService;
    private readonly IAvatarGeneratorService _avatarGeneratorService;

    public LaunchOrderCommandHandler(IApplicationDbContext context, IMapper mapper,
        IStringLocalizer<LaunchOrderCommandHandler> localizer, IIdentityService identityService,
        IAvatarGeneratorService avatarGeneratorService)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
        _identityService = identityService;
        _avatarGeneratorService = avatarGeneratorService;
    }

    public async Task<CarDto> Handle(LaunchOrderCommand request, CancellationToken cancellationToken)
    {
        var car = new Car { ModelId = request.ModelId, Year = request.Year, ColorId = request.ColorId, };

        var user = new CreateUserCommand(
                userName: request.UserFullName + request.UserNationalityId[.. 4],
                password: $"@Mac2024_2023",
                fullName: request.UserFullName,
                roleId: Roles.User)
            .WithDefaultAvatar(await _avatarGeneratorService.GetUserAvatar());

        // if (request.IsBroker)
        //     user.Role = "Broker";
        // else
        //     user.Role = "User";

        (Result result, UserDetailsResponse? newUser) =
            await _identityService.CreateUserAsync(user, cancellationToken);

        if (!result.Succeeded || newUser is null) throw new BadRequestException();

        car.Release = new Release { ReleaseDate = DateTime.Now.AddMonths(request.ReleasedAfterInMonths) };

        car.UserId = newUser.Id;

        await _context.Cars.AddAsync(car, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CarDto>(car);
    }
}
