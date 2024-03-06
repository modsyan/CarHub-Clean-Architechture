using System.ComponentModel;
using Mac.CarHub.Application.Common.Interfaces;
using Mac.CarHub.Application.Common.Models;
using Mac.CarHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using QuestPDF;
using QuestPDF.Fluent;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace Mac.CarHub.Infrastructure.Reports;

public class CarReportService(IApplicationDbContext context): ICarReportService
{
    public IApplicationDbContext Context { get; } = context;
    
    // public async Task<Stream> GeneratePdfAsync(CancellationToken cancellationToken)
    // {
    //     var document = Document.Create(
    //     );
    //
    //     var carReport = await GetCarReport(cancellationToken);
    //
    //     document.Pages.Add(AddEnteredCarsPage(carReport.EnteredCars));
    //     document.Pages.Add(AddOverallActivitiesPage(carReport.OverallActivities));
    //
    //     return document.GenerateStream();
    // }
    //
    // public async Task<CarReportModel> GetCarReport(CancellationToken cancellationToken)
    // {
    //     var enteredCars = await context.Cars
    //         .AsNoTracking()
    //         .Include(c => c.Model)
    //         .Include(c => c.Color)
    //         .Include(c => c.Inspection)
    //         .Include(c => c.Release)
    //         .Where(c => c.Created >= DateTime.Now.AddDays(-30))
    //         .ToListAsync(cancellationToken);
    //
    //     var overAllActives = await context.Events
    //         .AsNoTracking()
    //         .Where(e => e.Created >= DateTime.Now.AddDays(-30))
    //         .ToListAsync(cancellationToken);
    //
    //     return new CarReportModel { EnteredCars = enteredCars, OverallActivities = overAllActives };
    // }
    //
    //
    // // container.Margin(20);
    // // container.Header().Text("Entered Cars").FontSize(20).AlignCenter();
    // private static IContainer AddEnteredCarsPage(this IContainer container, List<Car> cars)
    // {
    //     // var table = container.Table((descriptor =>
    //     //         descriptor
    //     //             .Width(100, 100, 100, 100, 100, 100)
    //     //             .Columns(3)
    //     //             .Header()
    //     //             .Row()
    //     //             .Text("Engine Serial Number").FontSize(10).Bold().AlignCenter()
    //     //             .Text("Model").FontSize(10).Bold().AlignCenter()
    //     //             .Text("Year").FontSize(10).Bold().AlignCenter()
    //     //             .Text("Color").FontSize(10).Bold().AlignCenter()
    //     //             .Text("Inspection Status").FontSize(10).Bold().AlignCenter()
    //     //             .Text("Release Status").FontSize(10).Bold().AlignCenter();
    //
    //
    //     container.Table(table =>
    //     {
    //         table.ColumnsDefinition(columns =>
    //         {
    //             columns.RelativeColumn
    //         }
    //             
    //                 table.CellAddColumn("Engine Serial Number")
    //                 .AddColumn("Model")
    //                 .AddColumn("Year")
    //                 .AddColumn("Color")
    //                 .AddColumn("Inspection Status")
    //                 .AddColumn("Release Status");
    //     });
    //
    //     foreach (var car in cars)
    //     {
    //         table
    //             .AddRow(
    //                 car.EngineSerialNumber,
    //                 car.Model.Name,
    //                 car.Year,
    //                 car.Color.EnName,
    //                 car.Inspection != null ? "Passed" : "Pending",
    //                 car.Release != null ? "Released" : "Pending"
    //             );
    //     }
    // }


    public Task<CarReportModel> GetCarReportAsync(CancellationToken cancellationToken)
    {
        // var enteredCars = await context.Cars
        //     .AsNoTracking()
        //     .Include(c => c.Model)
        //     .Include(c => c.Color)
        //     .Include(c => c.Inspection)
        //     .Include(c => c.Release)
        //     .Where(c => c.Created >= DateTime.Now.AddDays(-30))
        //     .ToListAsync(cancellationToken);
        //
        // var overAllActives = await context.Events
        //     .AsNoTracking()
        //     .Where(e => e.Created >= DateTime.Now.AddDays(-30))
        //     .ToListAsync(cancellationToken);
        
        throw new NotImplementedException();
    }
}
