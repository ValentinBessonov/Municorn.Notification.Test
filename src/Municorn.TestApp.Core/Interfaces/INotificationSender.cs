using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Core.Interfaces;

public interface INotificationSender
{
    public Task<bool> SendNotificationAsync(INotification notification);
}

public interface INotificationSender<T>: INotificationSender
{
    public Task<bool> SendNotificationAsync(T notification);
}
