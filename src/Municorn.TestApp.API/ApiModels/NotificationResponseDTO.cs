using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.ApiModels;

public class NotificationResponseDTO
{
    public int NotificationId { get; }

    public NotificationStatusDTO NotificationStatus { get; }

    public NotificationResponseDTO(NotificationResponse response)
    {
        NotificationId = response.Id;
        NotificationStatus = new NotificationStatusDTO(response.IsDelivered);
    }
}
