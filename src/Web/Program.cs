using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Threading.RateLimiting;
using Azure;
using Mac.CarHub.Application.Common.Extension;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Infrastructure.Data;
using Mac.CarHub.Web;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NSwag;
using NSwag.AspNetCore;
using Serilog;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using OpenApiSecurityScheme = Microsoft.OpenApi.Models.OpenApiSecurityScheme;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

builder.Services.AddFileOptionConfiguration(builder.Configuration);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

// Localization and Culture Middlewares

var supportedCultures = new[] { "ar-EG", "en-US" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseEnumLocalizer();

// app.UseMiddleware<RequestRateLimitingMiddleware>();

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerFeature?.Error;

        if (exception != null)
        {
            var customExceptionHandler = new CustomExceptionHandler();
            await customExceptionHandler.TryHandleAsync(context, exception, default);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Detail = exception.Message,
                Extensions =
                {
                    // ["traceId"] = Activity.Current?.Id ?? context.TraceIdentifier,
                    ["exception"] = exception.StackTrace
                }
            });
        }
    });
});

app.Map("/", () => Results.Redirect("/api"));

app.UseStaticFiles();

app.MapEndpoints();

app.Run();

public partial class Program
{
}
