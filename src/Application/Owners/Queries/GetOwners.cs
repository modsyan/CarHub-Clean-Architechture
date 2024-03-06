using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Owners.Queries;

public record GetOwnersQuery : IRequest<OwnerVm>
{
}

public class GetOwnersQueryValidator : AbstractValidator<GetOwnersQuery>
{
    public GetOwnersQueryValidator()
    {
    }
}

public class GetOwnersQueryHandler : IRequestHandler<GetOwnersQuery, OwnerVm>
{
    private readonly IApplicationDbContext _context;

    public GetOwnersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<OwnerVm> Handle(GetOwnersQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
