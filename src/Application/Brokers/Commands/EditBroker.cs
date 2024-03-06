using Mac.CarHub.Application.Brokers.Queries;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Brokers.Commands;

public record EditBrokerCommand : IRequest<BrokerDto>
{
    public Guid Id { get; init; }

    public string? Name { get; init; } = null!;

    public string? Username { get; init; } = null!;

    public string? Email { get; init; } = null!;

    public string? PhoneNumber { get; init; } = null!;

    public string? NationalId { get; init; } = null!;

    public IFormFile? ProfilePicture { get; init; } = null!;
}

public class EditBrokerCommandValidator : AbstractValidator<EditBrokerCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IStringLocalizer<EditBrokerCommandValidator> _localizer;
    private readonly IIdentityService _identityService;

    public EditBrokerCommandValidator(IApplicationDbContext context, ICurrentUserService currentUserService,
        IStringLocalizer<EditBrokerCommandValidator> localizer, IIdentityService identityService)
    {
        _context = context;
        _currentUserService = currentUserService;
        _localizer = localizer;
        _identityService = identityService;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);

        RuleFor(c => c.Name)
            .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_LENGTH]);

        RuleFor(c => c.Username)
            .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_LENGTH])
            .MustAsync(BeUniqueUsername)
            .WithMessage(_localizer[SharedResourcesKeys.MESSAGE_VALIDATION_DUPLICATED_USERNAME]);

        RuleFor(c => c.Email)
            .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_LENGTH])
            .EmailAddress().WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_EMAIL])
            // .MustAsync(BeUniqueEmail).WithMessage(_localizer[SharedResourcesKeys.ERR_DUPLICATED])
            ;

        RuleFor(c => c.PhoneNumber)
            .MinimumLength(5).WithMessage(_localizer[SharedResourcesKeys.ERR_MIN_LENGTH])
            .MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_LENGTH]);

        RuleFor(c => c.NationalId)
            .MinimumLength(5).WithMessage(_localizer[SharedResourcesKeys.ERR_MIN_LENGTH])
            .MaximumLength(20).WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_LENGTH])
            // .MustAsync(BeUniqueNationalId).WithMessage(_localizer[SharedResourcesKeys.ERR_DUPLICATED])
            ;

        RuleFor(c => c.ProfilePicture)
            .Must(BeValidImage).WithMessage(_localizer[SharedResourcesKeys.ERR_INVALID_IMAGE]);
    }

    private static bool BeValidImage(IFormFile? file)
    {
        if (file == null) return true;

        return file.ContentType switch
        {
            "image/jpeg" => true,
            "image/png" => true,
            "image/jpg" => true,
            _ => false
        };
    }

    private async Task<bool> BeUniqueUsername(EditBrokerCommand brokerCommand, string username,
        CancellationToken cancellationToken)
    {
        return await _identityService.IsUsernameUniqueExceptAsync(username, brokerCommand.Id, cancellationToken);
    }

    // private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    // {
    //     return await _context.Brokers
    //         .AllAsync(b => b.Email != email && b.Id != _currentUserService.UserId, cancellationToken);
    // }

    // private async Task<bool> BeUniqueNationalId(string nationalId, CancellationToken cancellationToken)
    // {
    //     return await _context.Brokers
    //         .AllAsync(b => b.NationalId != nationalId && b.Id != _currentUserService.UserId, cancellationToken);
    // }
}

public class EditBrokerCommandHandler : IRequestHandler<EditBrokerCommand, BrokerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<EditBrokerCommandHandler> _localizer;

    public EditBrokerCommandHandler(IApplicationDbContext context, IIdentityService identityService, IMapper mapper,
        IStringLocalizer<EditBrokerCommandHandler> localizer)
    {
        _context = context;
        _identityService = identityService;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<BrokerDto> Handle(EditBrokerCommand request, CancellationToken cancellationToken)
    {
        var broker = await _context.Brokers
            .Where(b => b.Id == request.Id)
            .Include(broker => broker.Cars).ThenInclude(car => car.Model).ThenInclude(model => model.Make)
            .ProjectTo<BrokerDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        if (broker == null)
            throw new NotFoundException(_localizer[SharedResourcesKeys.ERR_NOT_FOUND], "Broker");

        var editUser = new EditUserCommand
        {
            Id = broker.UserId,
            Name = request.Name,
            Username = request.Username,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            NationalId = request.NationalId,
            ProfilePicture = request.ProfilePicture
        };

        (Result result, UserDetailsResponse? userDetails) =
            await _identityService.UpdateUserAsync(editUser, cancellationToken);

        if (!result.Succeeded || userDetails != null) throw new ValidationException("");

        broker.UserDetails = userDetails;

        return broker;
    }
}
