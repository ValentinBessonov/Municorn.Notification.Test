using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.ApiModels;

public class NotificationResponseDTO
{
    public int NotificationId { get; set; }

    public NotificationStatusDTO NotificationStatus { get; set; }

    public NotificationResponseDTO(NotificationResponse response)
    {
        NotificationId = response.Id;
        NotificationStatus = new NotificationStatusDTO(response.IsDelivered);
    }

    public NotificationResponseDTO()
    {

    }
}
