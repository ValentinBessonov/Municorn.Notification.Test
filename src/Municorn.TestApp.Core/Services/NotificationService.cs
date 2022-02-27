using Microsoft.Extensions.DependencyInjection;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAppRepository _repository;

        public NotificationService(IServiceProvider serviceProvider, IAppRepository repository)
        {
            _serviceProvider = serviceProvider;
            _repository = repository;
        }

        public bool GetNotificationDelivered(int id)
            => _repository.GetNotificationDelivered(id);

        public async Task<NotificationResponse> SaveAndSendAsync(INotification notification)
        {
            var response = notification switch
            {
                IosNotification iOSNotification => await SaveAndSend(
                    _repository.CreateNotificationAsync(iOSNotification),
                    _serviceProvider.GetRequiredService<INotificationSender<IosNotification>>(),
                    notification),
                AndroidNotification androidNotification => await SaveAndSend(
                    _repository.CreateNotificationAsync(androidNotification),
                    _serviceProvider.GetRequiredService<INotificationSender<AndroidNotification>>(),
                    notification),
                _ => throw new NotImplementedException($"Save and sending notification for type: {notification.GetType().FullName} not implemented"),
            };

            UpdateState(response);

            return response;
        }

        private async Task<NotificationResponse> SaveAndSend(Task<int> createTask, INotificationSender sender, INotification notification)
        {
            var isDelivered = await sender.SendNotificationAsync(notification);

            return new NotificationResponse()
            {
                Id = await createTask,
                IsDelivered = isDelivered
            };
        }

        private void UpdateState(NotificationResponse response)
        {
            _repository.UpdateNotificationStatusAsync(response);
        } 
    }
}
