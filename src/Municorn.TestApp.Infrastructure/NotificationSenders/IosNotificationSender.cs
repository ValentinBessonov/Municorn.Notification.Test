using Microsoft.Extensions.Logging;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Infrastructure.NotificationSenders;

public class IosNotificationSender : FakeNotificationSenderBase, INotificationSender<IosNotification>
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
        return await Send(notification);
    }
}
