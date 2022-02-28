using Municorn.TestApp.Core.Models;
using Municorn.TestApp.Infrastructure.Data;
using System.Threading.Tasks;
using Xunit;

namespace Municorn.TestApp.IntegrationTests.Data;

public class AppRepositoryTests : RepoTestFixture
{
    [Fact]
    public async Task ReturnsNewIdWhenAddNotification()
    {
        var repository = new AppRepository(_dbContext);

        var id = await repository.CreateNotificationAsync(new IosNotification()
        {
            Alert = "some alert",
            PushToken = "some token",
        });

        var id2 = await repository.CreateNotificationAsync(new AndroidNotification()
        {
            Title = "some alert",
            Message = "some token",
            DeviceToken = "some token"
        });

        Assert.True(id > 0);
        Assert.True(id2 > 0);
        Assert.True(id2 > id);
    }

    [Fact]
    public async Task ReturnsIdDeliveredFalseWhenAddNotification()
    {
        var repository = new AppRepository(_dbContext);

        var id = await repository.CreateNotificationAsync(new IosNotification()
        {
            Alert = "some alert",
            PushToken = "some token",
        });

        var isDelivered = repository.GetNotificationDelivered(id);

        Assert.False(isDelivered);
    }

    [Fact]
    public async Task ReturnsIdDeliveredTrueAfterUpdateNotification()
    {
        var repository = new AppRepository(_dbContext);

        var id = await repository.CreateNotificationAsync(new IosNotification()
        {
            Alert = "some alert",
            PushToken = "some token",
        });

        await repository.UpdateNotificationStatusAsync(new NotificationResponse
        {
            Id = id,
            IsDelivered = true
        });

        var isDelivered = repository.GetNotificationDelivered(id);

        Assert.True(isDelivered);
    }
}
