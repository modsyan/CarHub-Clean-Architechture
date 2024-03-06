using System.Linq.Expressions;
using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Mappings;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.StoredCarOrders.Queries.GetStoredCarOrderDetails;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Domain.Enums;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Orders.Queries;

public record GetOrdersQuery : IRequest<OrderVm>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SearchString { get; set; } = "";
    public string SortBy { get; set; } = "Created";

    public string SortOrder { get; set; } = "asc";

    public bool IsCompletedOnly { get; set; } = false;
}

public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
{
    private readonly IStringLocalizer<GetOrdersQueryValidator> _localizer;
    private readonly IApplicationDbContext _context;

    public GetOrdersQueryValidator(IStringLocalizer<GetOrdersQueryValidator> localizer, IApplicationDbContext context)
    {
        _localizer = localizer;
        _context = context;

        ApplyValidationRules();
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);

        RuleFor(x => x.SortBy)
            .NotEmpty().WithMessage(_localizer["SortBy is required"])
            .NotNull().WithMessage(_localizer["SortBy is required"]);

        RuleFor(x => x.SortOrder)
            .NotEmpty().WithMessage(_localizer["SortOrder is required"])
            .NotNull().WithMessage(_localizer["SortOrder is required"]);
    }
}

public class GetOrdersQueryHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<GetOrdersQuery, OrderVm>
{
    public async Task<OrderVm> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var query = context.Cars
            .Include(x => x.Model).ThenInclude(x => x.Make)
            .Include(x => x.Color)
            .Include(x => x.ParkingSlot)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchString))
        {
            query = query.Where(x =>
                x.Model.Name.Contains(request.SearchString) ||
                x.Model.Make.Name.Contains(request.SearchString) ||
                x.Color.ArName.Contains(request.SearchString) ||
                x.Color.EnName.Contains(request.SearchString) ||
                x.ParkingSlot != null && x.ParkingSlot.Title.Contains(request.SearchString) ||
                x.Status.GetDisplayName().Contains(request.SearchString)
            );
        }

        if (request.IsCompletedOnly)
        {
            query = query.Where(x => x.Status == CarStatus.Completed);
        }

        Expression<Func<Car, object>> orderBy = request.SortBy switch
        {
            "Date" => x => x.Created,
            "Model" => x => x.Model.Name,
            "Make" => x => x.Model.Make.Name,
            "Color" => x => x.Color.ArName,
            "ParkingSlot" => x => x.ParkingSlot!.Title,
            "Status" => x => x.Status,
            _ => x => x.Created
        };

        query = request.SortOrder == "desc" ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy);

        var orders = await query
            .ProjectTo<CarBriefDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return new OrderVm { List = orders };
    }
}
