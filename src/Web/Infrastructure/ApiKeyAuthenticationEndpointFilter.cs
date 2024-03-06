namespace Mac.CarHub.Web.Infrastructure;

public class ApiKeyAuthenticationEndpointFilter(IConfiguration configuration) : IEndpointFilter
{
    private const string ApiKeyHeaderName = "X-Api-Key";

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        // var headers = context.HttpContext.Request.Headers;
        //
        // if (headers.TryGetValue(ApiKeyHeaderName, out var apiKey) && !IsValidApiKey(apiKey.First()))
        // {
        //     throw new UnauthorizedAccessException("Invalid API Key");
        // }
        
        var apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];
        
        if (!IsValidApiKey(apiKey)) 
        {
            throw new UnauthorizedAccessException("Invalid API Key");
        }

        return await next(context);
    }

    private bool IsValidApiKey(string? apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            return false;
        }
        
        var validApiKey = configuration.GetValue<string>("ApiKey");
        
        return apiKey == validApiKey;
    }
}
