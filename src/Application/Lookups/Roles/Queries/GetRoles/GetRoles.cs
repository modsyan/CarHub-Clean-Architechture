using Mac.CarHub.Application.Common.Interfaces;

namespace Mac.CarHub.Application.Lookups.Roles.Queries.GetRoles;

public record GetRolesQuery : IRequest<RoleVm>;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, RoleVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;

    public GetRolesQueryHandler(IApplicationDbContext context, IIdentityService identityService)
    {
        _context = context;
        _identityService = identityService;
    }

    public async Task<RoleVm> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetRolesAsync(cancellationToken);
    }
}
