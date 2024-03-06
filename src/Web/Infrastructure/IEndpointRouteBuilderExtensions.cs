namespace Mac.CarHub.Web.Infrastructure;

public static class IEndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler,
        string pattern = "")
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapGet(pattern, handler)
            .WithName(handler.Method.Name)
            // .WithOpenApi() // moving from WebApplicationExtensions.MapGroup it is causes a bug in post IFormFileCollection
            ;

        return builder;
    }

    public static IEndpointRouteBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler,
        string pattern = "")
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapPost(pattern, handler)
            .WithName(handler.Method.Name) 
            // .WithOpenApi(); // moving from WebApplicationExtensions.MapGroup it is causes a bug in post IFormFileCollection
            .DisableAntiforgery()
            ;

        return builder;
    }

    public static IEndpointRouteBuilder MapPostWithFiles(this IEndpointRouteBuilder builder, Delegate handler,
        string pattern = "")
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapPost(pattern, handler)
            .WithName(handler.Method.Name)
            .DisableAntiforgery();

        return builder;
    }

    public static IEndpointRouteBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler, string pattern)
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapPut(pattern, handler)
            .WithName(handler.Method.Name)
            // .WithOpenApi() // moving from WebApplicationExtensions.MapGroup it is causes a bug in post IFormFileCollection
            .DisableAntiforgery()
            ;

        return builder;
    }

    public static IEndpointRouteBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler, string pattern)
    {
        Guard.Against.AnonymousMethod(handler);

        builder.MapDelete(pattern, handler)
            .WithName(handler.Method.Name)
            // .WithOpenApi() // moving from WebApplicationExtensions.MapGroup it is causes a bug in post IFormFileCollection
            ;

        return builder;
    }
}
