using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;

namespace Mac.CarHub.Application.Owners.Queries;

public record GetOwnerDetailsQuery : IRequest<OwnerDto>
{
}

public class GetOwnerDetailsQueryValidator : AbstractValidator<GetOwnerDetailsQuery>
{
    public GetOwnerDetailsQueryValidator()
    {
    }
}

public class GetOwnerDetailsQueryHandler : IRequestHandler<GetOwnerDetailsQuery, OwnerDto>
{
    private readonly IApplicationDbContext _context;

    public GetOwnerDetailsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<OwnerDto> Handle(GetOwnerDetailsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
