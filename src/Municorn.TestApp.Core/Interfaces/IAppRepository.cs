using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Core.Interfaces
{
    public interface IAppRepository
    {
        Task<int> CreateNotificationAsync(IosNotification notification);

        Task<int> CreateNotificationAsync(AndroidNotification notification);

        Task UpdateNotificationStatusAsync(NotificationResponse response);

        bool GetNotificationDelivered(int id);
    }
}
