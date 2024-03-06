using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Lookups.Models.Queries;

public record GetModelsQuery : IRequest<ModelVm>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? SearchString { get; set; }
    public int? MakeId { get; init; }
}

public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, ModelVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetModelsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModelVm> Handle(GetModelsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Models
                .AsNoTracking()
                .Where(m => request.MakeId == null || m.MakeId == request.MakeId)
                .Where(m => string.IsNullOrEmpty(request.SearchString) || m.Name.Contains(request.SearchString) ||
                            m.Make.Name.Contains(request.SearchString))
            ;

        if (request is { PageSize: not null })
            query = query.Take(request.PageSize.Value);

        if (request is { PageNumber: not null, PageSize: not null })
            query = query.Skip((request.PageNumber.Value - 1) * request.PageSize.Value);

        var models = await query
            .OrderBy(m => m.Name)
            .ProjectTo<ModelDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var totalItems = await _context.Models
            .Where(m => request.MakeId == null || m.MakeId == request.MakeId)
            .CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(totalItems / ((double)(request.PageSize ?? totalItems)));


        return new ModelVm
        {
            Models = models,
            TotalCount = models.Count,
            PageSize = models.Count,
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }
}
