namespace Municorn.TestApp.ApiModels;

public class NotificationResponseDTO
{
    public int NotificationId { get; }

    public NotificationStatusDTO NotificationStatus { get; }

    public NotificationResponseDTO(int id, bool isDelivered)
    {
        NotificationId = id;
        NotificationStatus = new NotificationStatusDTO(isDelivered);
    }
}
