using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Releasing.Queries;

public record GetReleasedCarsQuery : IRequest<ReleaseVm>;

public class GetReleasedCarsQueryHandler : IRequestHandler<GetReleasedCarsQuery, ReleaseVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<GetReleasedCarsQueryHandler> _localizer;

    public GetReleasedCarsQueryHandler(IApplicationDbContext context, IMapper mapper,
        IStringLocalizer<GetReleasedCarsQueryHandler> localizer)
    {
        _context = context;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<ReleaseVm> Handle(GetReleasedCarsQuery request, CancellationToken cancellationToken)
    {
        var releasedCars = await _context.Releases
            .Include(c => c.Car).ThenInclude(c => c.Model).ThenInclude(c => c.Make)
            .ProjectTo<ReleaseDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var vm = new ReleaseVm { Releases = releasedCars };

        return vm;
    }
}
