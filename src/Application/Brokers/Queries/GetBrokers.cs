using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AutoMapper.Execution;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models.DTOs;
using Mac.CarHub.Application.Common.Models.Identity;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Brokers.Queries;

public record GetBrokersQuery : IRequest<BrokerVm>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SearchString { get; set; } = string.Empty;
}

public class GetBrokersQueryValidator : AbstractValidator<GetBrokersQuery>
{
    public GetBrokersQueryValidator(IApplicationDbContext context,
        IStringLocalizer<GetBrokersQueryValidator> _localizer)
    {
        RuleFor(v => v.PageNumber)
            .GreaterThan(0)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_NUMBER_GREATER_THAN_ZERO]);

        RuleFor(v => v.PageSize)
            .GreaterThan(0)
            .WithMessage(_localizer[SharedResourcesKeys.ERR_PAGE_SIZE_GREATER_THAN_ZERO]);

        RuleFor(v => v.SearchString)
            .MaximumLength(50)
            .WithMessage(_localizer[SharedResourcesKeys.BROKER_ERROR_FILED_MAX]);
    }
}

public class GetBrokersQueryHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IIdentityService identityService)
    : IRequestHandler<GetBrokersQuery, BrokerVm>
{
    public async Task<BrokerVm> Handle(GetBrokersQuery request, CancellationToken cancellationToken)
    {
        var query = context.Brokers
            .AsNoTracking()
            .Include(b => b.Cars)
            .ThenInclude(c => c.Model)
            .ThenInclude(m => m.Make)
            .AsQueryable();


        if (!string.IsNullOrWhiteSpace(request.SearchString))
        {
            var expression = GetBrokerSearchExpression(request.SearchString);
            query = query.Where(expression);
        }

        // if (!string.IsNullOrWhiteSpace(request.SearchString))
        // {
        //     if (await IsSearchInUserDetailsAsync(request.SearchString, cancellationToken))
        //     {
        //         var userIds = await _context.Brokers.Select(b => b.UserId).ToListAsync(cancellationToken);
        //         query = query.Where(b => userIds.Contains(b.UserId));
        //     }
        // }

        // if (request.SearchString is not null &&
        //     await IsSearchInUserDetailsAsync(request.SearchString, cancellationToken))
        // {
        //     // query = query.Where(async b => await IsSearchInUserDetailsAsync(request.SearchString, cancellationToken));
        // }

        var brokers = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<BrokerDto>(mapper.ConfigurationProvider)
            .OrderBy(b => b.Cars.Count)
            .ToListAsync(cancellationToken);

        foreach (var broker in brokers)
        {
            broker.UserDetails = await identityService.GetUserDetailsAsync(broker.UserId);
        }

        var totalBrokers = context.Brokers.Count();

        return new BrokerVm { Brokers = brokers, TotalCount = totalBrokers };
    }

    private Expression<Func<Broker, bool>> GetBrokerSearchExpression(string searchString)
    {
        return broker =>
            broker.Cars.Any(c => c.Model.Name.Contains(searchString)) ||
            broker.Cars.Any(c => c.Model.Make.Name.Contains(searchString)) ||
            broker.Cars.Any(c => c.Year.ToString().Contains(searchString));
    }

    private async Task<bool> IsSearchInUserDetailsAsync(string searchString, CancellationToken cancellationToken)
    {
        var userIds = await context.Brokers.Select(b => b.UserId).ToListAsync(cancellationToken);

        foreach (var userId in userIds)
        {
            var userDetails = await identityService.GetUserDetailsAsync(userId);

            if (userDetails == null) continue;

            var isInUserName = userDetails.UserName.Contains(searchString);

            var isInEmail = !string.IsNullOrWhiteSpace(userDetails.Email) &&
                            userDetails.Email.Contains(searchString);

            var isInPhoneNUmber = !string.IsNullOrWhiteSpace(userDetails.PhoneNumber) &&
                                  userDetails.PhoneNumber.Contains(searchString);

            if (isInUserName || isInEmail || isInPhoneNUmber) return true;
        }

        return false;
    }

    // private async Task<Expression<Func<Broker, bool>>> IsSearchInUserDetailsExpression(string searchString)
    // {
    //     var userIds = await _context.Brokers.Select(b => b.UserId).ToListAsync();
    //
    //     var userDetailsExpressions = new List<Expression<Func<UserDetailsResponse, bool>>>();
    //
    //     foreach (var userId in userIds)
    //     {
    //         var userDetails = await _identityService.GetUserDetailsAsync(userId);
    //
    //         if (userDetails == null) continue;
    //
    //         var isInUserName = userDetails.UserName.Contains(searchString);
    //         var isInEmail = !string.IsNullOrWhiteSpace(userDetails.Email) && userDetails.Email.Contains(searchString);
    //         var isInPhoneNumber = !string.IsNullOrWhiteSpace(userDetails.PhoneNumber) &&
    //                               userDetails.PhoneNumber.Contains(searchString);
    //
    //         Expression<Func<UserDetailsResponse, bool>> userExpression = u =>
    //             (isInUserName && u.UserName == userDetails.UserName) ||
    //             (isInEmail && u.Email == userDetails.Email) ||
    //             (isInPhoneNumber && u.PhoneNumber == userDetails.PhoneNumber);
    //
    //         userDetailsExpressions.Add(userExpression);
    //     }
    //
    //     // Combine all user expressions with OR operator
    //     // Expression<Func<UserDetailsResponse, bool>> combinedUserExpression = userDetailsExpressions
    //     //     .Aggregate((Expression<Func<UserDetailsResponse, bool>>)Expression.Constant(false), (current, next) =>
    //     //         Expression.OrElse(current, next));
    //
    //     // Expression<Func<UserDetails, bool>> combinedUserExpression = userDetailsExpressions
    //     //     .Aggregate((Expression<Func<UserDetails, bool>>)Expression.Constant(false), (current, next) =>
    //     //         Expression.OrElse(current, next));
    //     //
    //     // // Build broker expression by checking if any user detail satisfies the condition
    //     // Expression<Func<Broker, bool>> brokerExpression = broker =>
    //     //     userDetailsExpressions.Any(userExp =>
    //     //         broker.UserId == userExp.Parameters[0].Name && userExp.Body.NodeType == ExpressionType.Invoke);
    //     // Combine all user expressions with OR operator
    //
    //     // Expression<Func<UserDetailsResponse, bool>> combinedUserExpression = userDetailsExpressions
    //     //     .Aggregate<Expression<Func<UserDetailsResponse, bool>>, Expression<Func<UserDetailsResponse, bool>>>(null!,
    //     //         (current, next) => Expression.Lambda<Func<UserDetailsResponse, bool>>(
    //     //             Expression.OrElse(
    //     //                 Expression.Invoke(current, next.Parameters),
    //     //                 Expression.Invoke(next, next.Parameters)
    //     //             ),
    //     //             next.Parameters
    //     //         ));
    //     //
    //     // // Build broker expression by checking if any user detail satisfies the condition
    //     // Expression<Func<Broker, bool>> brokerExpression = broker =>
    //     //     userDetailsExpressions.Any(userExp =>
    //     //         userExp.Body.NodeType == ExpressionType.Invoke &&
    //     //         userExp.Parameters[0].Name == nameof(UserDetailsResponse.Id) &&
    //     //         Expression.Lambda<Func<string>>(Expression.Property(broker.Property(nameof(Broker.UserId))), null)
    //     //             .Compile().Invoke() == userExp.Parameters[0].Name);
    //
    //     Expression<Func<UserDetailsResponse, bool>> combinedUserExpression = null;
    //     foreach (var userExp in userDetailsExpressions)
    //     {
    //         if (combinedUserExpression == null)
    //             combinedUserExpression = userExp;
    //         else
    //         {
    //             var parameter = Expression.Parameter(typeof(UserDetailsResponse), "u");
    //             var orExpression = Expression.OrElse(
    //                 Expression.Invoke(combinedUserExpression, parameter),
    //                 Expression.Invoke(userExp, parameter)
    //             );
    //             combinedUserExpression = Expression.Lambda<Func<UserDetailsResponse, bool>>(orExpression, parameter);
    //         }
    //     }
    //
    //     // // Build broker expression by checking if any user detail satisfies the condition
    //     // Expression<Func<Broker, bool>> brokerExpression = broker =>
    //     // {
    //     //     UserDetailsResponse? userDetailsResponse = _identityService.GetUserDetailsAsync(broker.UserId).Result;
    //     //
    //     //     return userIds.Contains(broker.UserId) &&
    //     //            combinedUserExpression != null &&
    //     //            combinedUserExpression.Compile().Invoke(userDetailsResponse!);
    //     // };
    //
    //     return brokerExpression;
    // }
}
