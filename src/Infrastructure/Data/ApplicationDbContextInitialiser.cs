using System.Runtime.InteropServices;
using Mac.CarHub.Domain.Constants;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Infrastructure.Data.Seeders;
// using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Mac.CarHub.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<ApplicationRole> roleManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
            await CarSeeder.SeedAsync(_context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        var administratorRole = new ApplicationRole { Name = Roles.Administrator };

        // broker role
        var brokerRole = new ApplicationRole { Name = Roles.Broker };

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        if (_roleManager.Roles.All(r => r.Name != brokerRole.Name))
        {
            await _roleManager.CreateAsync(brokerRole);
        }

        // Default users
        var administrator = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            FirstName = "Head",
            LastName = "Office",
            UserName = "HeadOffice",
            Email = "headoffice@localhost",
            ProfilePicture = new UploadedFile
            {
                Id = Guid.NewGuid(),
                FileName = $"headoffice.jpg",
                FilePath = "/assets/uploads/headoffice.jpg",
                ContentType = "image/jpeg"
            }
        };

        if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await _userManager.CreateAsync(administrator, "@Qwe1234");
            if (!string.IsNullOrWhiteSpace(administratorRole.Name))
            {
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }
        }

        if (!_context.Makes.Any())
        {
            await _context.AddRangeAsync(MakeSeedersData.GetMakes());

            await _context.SaveChangesAsync();
        }

        if (!_context.Colors.Any())
        {
            await _context.AddRangeAsync(ColorData.GetColors());
            
            await _context.SaveChangesAsync();
        }
    }
}
