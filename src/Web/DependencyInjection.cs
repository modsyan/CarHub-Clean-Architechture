using System.Globalization;
using System.Text.Json.Serialization;
using Azure.Identity;
using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Infrastructure.Data;
using Mac.CarHub.Web.Localization;
using Mac.CarHub.Web.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.OpenApi.Any;
using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using NSwag.Generation.Processors.Security;
using ZymLabs.NSwag.FluentValidation;
using FileOptions = Mac.CarHub.Infrastructure.Configurations.FileOptions;

namespace Mac.CarHub.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddRazorPages();

        services.AddScoped(provider =>
        {
            var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
            var loggerFactory = provider.GetService<ILoggerFactory>();

            return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
        });


        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        services.AddSwaggerConfig();
        services.AddJsonLocalization();
        services.AddDistributedMemoryCache();

        return services;
    }

    public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var keyVaultUri = configuration["KeyVaultUri"];
        if (!string.IsNullOrWhiteSpace(keyVaultUri))
        {
            configuration.AddAzureKeyVault(
                new Uri(keyVaultUri),
                new DefaultAzureCredential());
        }

        return services;
    }

    public static IServiceCollection AddFileOptionConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<FileOptions>(configuration.GetSection(FileOptions.SectionName));

        return services;
    }


    private static IServiceCollection AddJsonLocalization(this IServiceCollection services)
    {
        services.AddLocalization();
        services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

        services.AddMvc()
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(JsonStringLocalizerFactory));
            });

        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[] { new CultureInfo("ar-EG"), new CultureInfo("en-US"), };

            options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0]);
            options.SupportedCultures = supportedCultures;
        });
        return services;
    }

    private static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "Mac.CarHub API";

            // Add the fluent validations schema processor
            var fluentValidationSchemaProcessor =
                sp.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

            // BUG: SchemaProcessors is missing in NSwag 14 (https://github.com/RicoSuter/NSwag/issues/4524#issuecomment-1811897079)
            // configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);

            configure.AddSecurity("XApiKey", Enumerable.Empty<string>(),
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "X-Api-Key",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the text-box: X-Api-Key {your API key}."
                });

            configure.AddSecurity("JWT", Enumerable.Empty<string>(),
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the text-box: Bearer {your JWT token}."
                });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("XApiKey"));
            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));

            configure.OperationProcessors.Add(new AcceptLanguageHeaderParameter());

            // var acceptLanguage = new OpenApiParameter
            // {
            //     Name = "Accept-Language",
            //     Kind = OpenApiParameterKind.Header,
            //     Description = "Language preference for the response.",
            //     IsRequired = false,
            //     IsNullableRaw = true,
            //     Default = new OpenApiString("ar-EG"),
            //     Schema = new NJsonSchema.JsonSchema()
            //     {
            //         Type = NJsonSchema.JsonObjectType.String,
            //         Item = new NJsonSchema.JsonSchema() { Type = NJsonSchema.JsonObjectType.String },
            //         Enumeration = { new OpenApiString("ar-EG"), new OpenApiString("en-US") }
            //     },
            // };
            //
            // configure.OperationProcessors.Add(new AddGlobalParameterProcessor(acceptLanguage));

            // convert from List<IFromFIle> to list of files
            configure.OperationProcessors.Add(new FileUploadOperationProcessor());
        });
        return services;
    }

    public class FileUploadOperationProcessor : IOperationProcessor
    {
        public bool Process(OperationProcessorContext context)
        {
            var parameters = context.OperationDescription.Operation.Parameters;
            foreach (var parameter in parameters)
            {
                if (parameter.Kind == OpenApiParameterKind.FormData)
                {
                    var schema = parameter.Schema;
                    if (schema.Type == JsonObjectType.Array)
                    {
                        var items = schema.Item;
                        if (items != null)
                        {
                            parameter.Schema = items;
                        }
                    }
                }
            }

            return true;
        }
    }


    public class AddGlobalParameterProcessor : IOperationProcessor
    {
        private readonly OpenApiParameter _parameter;

        public AddGlobalParameterProcessor(OpenApiParameter parameter)
        {
            _parameter = parameter;
        }

        public bool Process(OperationProcessorContext context)
        {
            // Add the global parameter to the operation parameters
            context.OperationDescription.Operation.Parameters.Add(_parameter);
            return true;
        }
    }

    public static IApplicationBuilder UseEnumLocalizer(this IApplicationBuilder app)
    {
        var localizer = app.ApplicationServices.GetRequiredService<IStringLocalizer<EnumLocalizerService>>();
        var enumLocalizerService = new EnumLocalizerService(localizer);
        EnumLocalizerExtensions.Initialize(enumLocalizerService);

        return app;
    }
}
