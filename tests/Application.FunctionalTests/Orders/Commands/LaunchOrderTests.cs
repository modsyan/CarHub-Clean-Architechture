using Mac.CarHub.Application.StoredCarOrders.Commands;

namespace Mac.CarHub.Application.FunctionalTests.Orders.Commands;

using static Testing;

public class LaunchOrderTests: BaseTestFixture
{
    
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new LaunchOrderCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Test]
    public async Task ShouldProvideEngineSerialNumber()
    {
        await SendAsync(new LaunchOrderCommand
        {
            EngineSerialNumber = "123456"
        });
        
        var command = new LaunchOrderCommand
        {
            EngineSerialNumber = "123456"
        };
        
        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Test]
    public async Task ShouldCreateOrder()
    {
        var userId = await RunAsDefaultUserAsync();
        
        var command = new LaunchOrderCommand
        {
            EngineSerialNumber = "123456"
        };
        
        var id = await SendAsync(command);
        
        var order = await FindAsync<Order>(id);
        
        order.Should().NotBeNull();
        order!.EngineSerialNumber.Should().Be(command.EngineSerialNumber);
        order.CreatedBy.Should().Be(userId);
        order.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
    }
}
