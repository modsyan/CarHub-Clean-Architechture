using Mac.CarHub.Application.Brokers.Queries;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Application.Models;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Brokers.Commands;

public record CreateBrokerCommand : IRequest<BrokerDto>
{
    public string Name { get; init; } = null!;
    public string Username { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;

    public string NationalId { get; init; } = null!;
    public IFormFile? ProfilePicture { get; init; }
}

public class CreateBrokerCommandValidator : AbstractValidator<CreateBrokerCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;
    private readonly IStringLocalizer<CreateBrokerCommandValidator> _localizer;

    public CreateBrokerCommandValidator(IApplicationDbContext context,
        IStringLocalizer<CreateBrokerCommandValidator> localizer, IIdentityService identityService)
    {
        _context = context;
        _localizer = localizer;
        _identityService = identityService;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            // .MaximumLength(200).WithMessage(_localizer[SharedResourcesKeys.ERR_REGEX_COMMON_INPUT_MAX_LENGTH, 200])
            ;

        RuleFor(v => v.Username)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MinimumLength(7).WithMessage(_localizer[SharedResourcesKeys.MESSAGE_VALIDATION_USERNAME_LENGTH])
            .MaximumLength(15).WithMessage(_localizer[SharedResourcesKeys.MESSAGE_VALIDATION_USERNAME_LENGTH])
            .MustAsync(BeUniqueUsername)
            .WithMessage(_localizer[SharedResourcesKeys.MESSAGE_VALIDATION_DUPLICATED_USERNAME]);


        RuleFor(v => v.Email)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MaximumLength(200).WithMessage(_localizer[SharedResourcesKeys.ERR_MAX_LENGTH, 200])
            .EmailAddress().WithMessage(_localizer[SharedResourcesKeys.MESSAGE_VALIDATION_EMAIL_PATTERN])
            .MustAsync(BeUniqueEmail).WithMessage(_localizer[SharedResourcesKeys.ERR_DUPLICATED]);


        RuleFor(v => v.PhoneNumber)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MinimumLength(7).WithMessage(_localizer[SharedResourcesKeys.ERR_REGEX_PHONE_NO])
            .MaximumLength(15).WithMessage(_localizer[SharedResourcesKeys.ERR_REGEX_PHONE_NO]);

        // RuleFor(v => v.ProfilePicture)
        //     .NotNull().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
        //     .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED]);
    }

    private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
    {
        return await _identityService.IsUsernameUniqueAsync(username);
    }

    private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
    {
        return await _identityService.IsEmailUniqueAsync(email);
    }
}

public class CreateBrokerCommandHandler : IRequestHandler<CreateBrokerCommand, BrokerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<CreateBrokerCommandHandler> _localizer;
    private readonly IFileService _fileService;
    private readonly IAvatarGeneratorService _avatarGeneratorService;

    public CreateBrokerCommandHandler(IApplicationDbContext context, IIdentityService identityService, IMapper mapper,
        IStringLocalizer<CreateBrokerCommandHandler> localizer, IFileService fileService,
        IAvatarGeneratorService avatarGeneratorService)
    {
        _context = context;
        _identityService = identityService;
        _mapper = mapper;
        _localizer = localizer;
        _fileService = fileService;
        _avatarGeneratorService = avatarGeneratorService;
    }

    public async Task<BrokerDto> Handle(CreateBrokerCommand request, CancellationToken cancellationToken)
    {
        var user = await CreateUserCommand(request);

        (_, UserDetailsResponse? createdUser) = await _identityService.CreateUserAsync(user, cancellationToken);

        if (createdUser is null) throw new Exception(_localizer[SharedResourcesKeys.ERR_CREATE_FAILED]);

        // Guard.Against.Null(createdUser);

        var broker = new Broker { UserId = createdUser.Id };

        await _context.Brokers.AddAsync(broker, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        var brokerDto = _mapper.Map<BrokerDto>(broker);

        brokerDto.UserDetails = createdUser;

        return brokerDto;
    }

    private async Task<CreateUserCommand> CreateUserCommand(CreateBrokerCommand request)
    {
        var user = new CreateUserCommand(request.Username, $"@Mac2024_{request.Username}", request.Name, Roles.Broker);

        user = request.ProfilePicture is not null
            ? user.WithPersonalPhoto(request.ProfilePicture)
            : user.WithDefaultAvatar(await _avatarGeneratorService.GetBrokerAvatar());

        return user;
    }
}
