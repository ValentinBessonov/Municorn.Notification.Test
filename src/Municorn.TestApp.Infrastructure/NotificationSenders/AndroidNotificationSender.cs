using Microsoft.Extensions.Logging;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;
using System.Text.Json;

namespace Municorn.TestApp.Infrastructure.NotificationSenders;

public class AndroidNotificationSender : FakeNotificationSender, INotificationSender<AndroidNotification>
{
    public AndroidNotificationSender(ILogger<AndroidNotificationSender> logger): base(logger)
    {
    }

    public async Task<bool> SendNotificationAsync(INotification notification)
    {
        return await SendNotificationAsync((AndroidNotification)notification);
    }

    public async Task<bool> SendNotificationAsync(AndroidNotification notification)
    {
        Logger.LogInformation(JsonSerializer.Serialize(notification));
        return await Send(notification);
    }
}
