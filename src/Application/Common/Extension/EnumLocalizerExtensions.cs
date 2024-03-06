using System.ComponentModel.DataAnnotations;
using Mac.CarHub.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Mac.CarHub.Application.Common.Extension;

public static class EnumLocalizerExtensions
{
    // private static IServiceProvider? s_serviceProvider;
    private static IStringLocalizer? s_localizer;

    public static void Initialize( /*IServiceProvider serviceProvider,*/ IStringLocalizer localizer)
    {
        // s_serviceProvider = serviceProvider;
        s_localizer = localizer;
    }


    public static string GetDisplayName(this RequestStatus status)
    {
        // if (s_serviceProvider == null)
        //     throw new InvalidOperationException("Service provider is not initialized");

        // var localizer = s_serviceProvider.GetRequiredService<IStringLocalizer<RequestStatus>>();

        if (s_localizer == null)
            throw new InvalidOperationException("Localizer is not initialized");

        var current = status switch
        {
            RequestStatus.Pending => EnumHelper.GetDisplayName(RequestStatus.Pending),
            RequestStatus.Approved => EnumHelper.GetDisplayName(RequestStatus.Approved),
            RequestStatus.Denied => EnumHelper.GetDisplayName(RequestStatus.Denied),
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };

        return s_localizer[current];
    }

    public static string GetDisplayName(this CarStatus status)
    {
        // if (s_serviceProvider == null)
        //     throw new InvalidOperationException("Service provider is not initialized");

        // var localizer = s_serviceProvider.GetRequiredService<IStringLocalizer>

        if (s_localizer == null)
            throw new InvalidOperationException("Localizer is not initialized");

        var current = status switch
        {
            CarStatus.Pending => EnumHelper.GetDisplayName(CarStatus.Pending),
            CarStatus.Completed => EnumHelper.GetDisplayName(CarStatus.Completed),
            CarStatus.Rejected => EnumHelper.GetDisplayName(CarStatus.Rejected),
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };

        return s_localizer[current];
    }
}

public static class EnumHelper
{
    public static string GetDisplayName(Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var displayAttribute = (DisplayAttribute)Attribute.GetCustomAttribute(field!, typeof(DisplayAttribute))!;
        return displayAttribute?.Name ?? value.ToString();
    }
}
