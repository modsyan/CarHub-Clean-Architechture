using IronPdf;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Application.Reports.Queries;
using Microsoft.AspNetCore.Http.HttpResults;
using Razor.Templating.Core;

namespace Mac.CarHub.Web.Endpoints;

public class Reports : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCarReport);
    }

    private static async Task<FileContentHttpResult> GetCarReport(ISender sender)
    {
        var result = await sender.Send(new GetCarReportLast30DaysQuery());
        
        var html = await RazorTemplateEngine
            .RenderAsync("Views/Reports/CarReport.cshtml", result);
        
        var renderer = new ChromePdfRenderer();
        
        var pdf = renderer.RenderHtmlAsPdf(html);
        
        return TypedResults.File(
            pdf.BinaryData,
            "application/pdf",
            $"CarReport-{DateTime.Now:yyyy-MM-dd}.pdf"
        );
    }
    
    // private static Task<FileContentHttpResult> GetCarReport(ISender sender)
    // {
    //     
    //     throw new NotImplementedException();
    // }
}
 
