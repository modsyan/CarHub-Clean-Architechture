using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Infrastructure.Data;
using Mac.CarHub.Infrastructure.Data.Interceptors;
using Mac.CarHub.Infrastructure.Files;
using Mac.CarHub.Infrastructure.Identity;
using Mac.CarHub.Infrastructure.Services.Brokers;
using Mac.CarHub.Infrastructure.Services.Cars;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.AvatarGenerator;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddScoped<IBrokerService, BrokerService>();
        services.AddScoped<IFileService, FileService>();
        services.AddTransient<ICarService, CarService>();
        services.AddHttpClient<IAvatarGeneratorService, AvatarGeneratorService>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));

        
        //define iron suite license key
        
        License.LicenseKey =
            "IRONSUITE.MODCLOVER7.GMAIL.COM.27298-D85AC16E99-CFWG6TQ-INXMSXYLSG2L-245NAEBZEBXR-CTS2FVSNQXPB-64GXTZRNI4CR-GY6SAMJ6HR3A-YQGSDJYLB23Q-FKBT35-TSVOGVOLKGOMEA-DEPLOYMENT.TRIAL-LBMV4R.TRIAL.EXPIRES.28.MAR.2024";
                

        return services;
    }
}
