using System.Text;
using FluentValidation;
using Mac.CarHub.Application.Brokers.Commands;
using Mac.CarHub.Domain.Entities;
using Mac.CarHub.Infrastructure.Identity;
using Mac.CarHub.Web.Endpoints;
using Microsoft.AspNetCore.Http;

namespace Mac.CarHub.Application.FunctionalTests.Brokers.Commands;

using static Testing;

public class CreateBroker : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateBrokerCommand();

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateBrokerWithProfilePicture()
    {
        var bytes = Encoding.UTF8.GetBytes("Hello World from a Fake File");

        IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "dummy.txt");

        var command = new CreateBrokerCommand
        {
            Name = "Broker", Username = "example", Email = "example@ho.com", ProfilePicture = file,
        };
        
        var brokerId = await SendAsync(command);
        
        var broker = await FindAsync<Broker>(brokerId);
        
        var brokerUserDetails = await FindAsync<ApplicationUser>(brokerId);
        
        broker.Should().NotBeNull();
        brokerUserDetails?.FullName.Should().Be(command.Name);
        brokerUserDetails?.UserName.Should().Be(command.Username);
        brokerUserDetails?.Email.Should().Be(command.Email);
        brokerUserDetails?.ProfilePicture.Should().NotBeNull();
    }
}
