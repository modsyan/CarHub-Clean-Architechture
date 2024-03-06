using System.Reflection;

namespace Mac.CarHub.Web.Infrastructure;

public static class WebApplicationExtensions
{
    public static RouteGroupBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
    {
        var groupName = group.GetType().Name;

        return app
                .MapGroup($"/api/{groupName}")
                .WithGroupName(groupName)
                .WithTags(groupName)
                .WithOpenApi() // moving from IEndpointRouteBuilderExtensions.MapGet it is causes a bug in post IFormFileCollection
                .AddEndpointFilter<ApiKeyAuthenticationEndpointFilter>()
                .RequireAuthorization()
            ;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var endpointGroupType = typeof(EndpointGroupBase);

        var assembly = Assembly.GetExecutingAssembly();

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
