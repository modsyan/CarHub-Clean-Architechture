using System.Globalization;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Lookups.Colors.Queries;

public record GetColorsQuery : IRequest<ColorVm>;

public class GetColorsQueryHandler : IRequestHandler<GetColorsQuery, ColorVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetColorsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ColorVm> Handle(GetColorsQuery request, CancellationToken cancellationToken)
    {
        var culture = CultureInfo.CurrentCulture.Name;

        var colors = await _context.Colors
            // .ProjectTo<ColorDto>(_mapper.ConfigurationProvider)
            .Select(c => new ColorDto { Id = c.Id, LocalizedName = culture == "en-US" ? c.EnName : c.ArName })
            .ToListAsync(cancellationToken);

        return new ColorVm { Colors = colors };
    }
}
