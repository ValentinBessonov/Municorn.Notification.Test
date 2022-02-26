using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Core.Interfaces
{
    public interface INotificationService
    {
        public bool GetNotificationDelivered(int id);
        public Task<NotificationResponse> SaveAndSendAsync(INotification notification);
    }
}
