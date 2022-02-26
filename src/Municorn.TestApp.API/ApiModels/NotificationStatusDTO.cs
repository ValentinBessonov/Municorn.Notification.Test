namespace Municorn.TestApp.ApiModels
{
    public class NotificationStatusDTO
    {
        public string NotificationStatus { get; }

        public NotificationStatusDTO(bool isDelivered)
        {
            NotificationStatus = isDelivered ? "Доставлено" : "Не доставлено";
        }
    }
}
