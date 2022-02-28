using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Core.Interfaces
{
    public interface IAppRepository
    {
        Task<int> CreateNotificationAsync<T>(T notification)
            where T : class, INotification;

        Task UpdateNotificationStatusAsync(NotificationResponse response);

        bool GetNotificationDelivered(int id);
    }
}
