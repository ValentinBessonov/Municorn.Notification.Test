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

        public async Task<NotificationResponse> SaveAndSendAsync<T>(T notification)
            where T : class, INotification
        {
            var createTask = _repository.CreateNotificationAsync(notification);
            var sendTask = _serviceProvider.GetRequiredService<INotificationSender<T>>().SendNotificationAsync(notification);

            var response = new NotificationResponse()
            {
                Id = await createTask,
                IsDelivered = await sendTask
            };

            UpdateStateBackground(response);

            return response;
        }
        private void UpdateStateBackground(NotificationResponse response)
        {
            _repository.UpdateNotificationStatusAsync(response);
        }
    }
}
