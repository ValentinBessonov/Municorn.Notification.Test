using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.ApiModels
{
    public class NotificationDTO
    {
        public IosNotification? IosNotification { get; set; }
        public AndroidNotification? AndroidNotification { get; set; }
    }
}
