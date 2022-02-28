using Microsoft.Extensions.Logging;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;
using System.Text.Json;

namespace Municorn.TestApp.Infrastructure.NotificationSenders;

public class IosNotificationSender : FakeNotificationSender, INotificationSender<IosNotification>
{
    public IosNotificationSender(ILogger<IosNotificationSender> logger) : base(logger)
    {
    }

    public async Task<bool> SendNotificationAsync(INotification notification)
    {
        return await SendNotificationAsync((IosNotification)notification);
    }

    public async Task<bool> SendNotificationAsync(IosNotification notification)
    {
        Logger.LogInformation(JsonSerializer.Serialize(notification));
        return await Send(notification);
    }
}
