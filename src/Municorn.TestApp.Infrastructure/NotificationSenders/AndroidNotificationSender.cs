using Microsoft.Extensions.Logging;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Infrastructure.NotificationSenders;

public class AndroidNotificationSender : FakeNotificationSenderBase, INotificationSender<AndroidNotification>
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
        return await Send(notification);
    }
}
