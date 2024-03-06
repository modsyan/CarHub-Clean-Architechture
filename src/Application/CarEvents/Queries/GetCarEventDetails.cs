using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.CarEvents.Queries;

public record GetCarEventDetailsQuery(Guid Id) : IRequest<EventDto>;

public class GetCarEventDetailsQueryValidator : AbstractValidator<GetCarEventDetailsQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly IStringLocalizer<GetCarEventDetailsQueryValidator> _localizer;

    public GetCarEventDetailsQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetCarEventDetailsQueryValidator> localizer)
    {
        _context = context;
        _localizer = localizer;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.ERR_REQUIRED])
            .MustAsync(EventExists).WithMessage(_localizer[SharedResourcesKeys.ERR_NOT_FOUND]);
    }

    private async Task<bool> EventExists(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Events.AnyAsync(e => e.Id == id, cancellationToken);
    }
}

public class GetCarEventDetailsQueryHandler : IRequestHandler<GetCarEventDetailsQuery, EventDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetCarEventDetailsQueryHandler> _localizer;

    public GetCarEventDetailsQueryHandler(IApplicationDbContext context, IMapper mapper,
        IStringLocalizer<GetCarEventDetailsQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<EventDto> Handle(GetCarEventDetailsQuery request, CancellationToken cancellationToken)
    {
        var eventDto = await _context.Events
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(cancellationToken);

        return eventDto ?? throw new NotFoundException(nameof(Event), request.Id.ToString());
    }
}
