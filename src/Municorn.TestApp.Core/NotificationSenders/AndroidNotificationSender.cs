using Microsoft.Extensions.Logging;
using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Core.NotificationSenders
{
    public class AndroidNotificationSender: INotificationSender<AndroidNotification>
    {
        private ILogger<AndroidNotificationSender> _logger;

        public AndroidNotificationSender(ILogger<AndroidNotificationSender> logger)
        {
            _logger = logger;
        }

        public async Task<bool> SendNotificationAsync(INotification notification)
        {
            return await SendNotificationAsync((AndroidNotification)notification);
        }

        public Task<bool> SendNotificationAsync(AndroidNotification notification)
        {
            throw new NotImplementedException();
        }
    }
}
