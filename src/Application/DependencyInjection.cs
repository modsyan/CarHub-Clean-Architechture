using System.Reflection;
using Mac.CarHub.Application.Common.Behaviours;
using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Application.Common.Interfaces;
using Microsoft.Extensions.Localization;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });

        services.AddScoped<EnumLocalizerService>();
        //
        // var localizer = services.BuildServiceProvider().GetRequiredService<IStringLocalizer<EnumLocalizerService>>();
        // var enumLocalizerService = new EnumLocalizerService(localizer);
        // EnumLocalizerExtensions.Initialize(enumLocalizerService);
        //
        return services;
    }
}
