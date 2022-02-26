using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Core.NotificationSenders
{
    public class IosNotificationSender : INotificationSender<IosNotification>
    {
        private IAppRepository _appRepository;

        public IosNotificationSender(IAppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public async Task<bool> SendNotificationAsync(INotification notification)
        {
            return await SendNotificationAsync((IosNotification)notification);
        }

        public Task<bool> SendNotificationAsync(IosNotification notification)
        {
            throw new NotImplementedException();
        }
    }
}
