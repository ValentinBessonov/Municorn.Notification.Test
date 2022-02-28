using Microsoft.AspNetCore.Mvc;
using Municorn.TestApp.ApiModels;
using Municorn.TestApp.Core;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;

namespace Notification.Api;

[ApiController]
public class NotificationController : ControllerBase
{
    private INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    /// <summary>
    /// Get notification status
    /// </summary>
    /// <param name="id">identificator</param>
    /// <returns>notification status</returns>
    [HttpGet]
    [Route("NotificationStatus")]
    public NotificationStatusDTO GetNotificationStatus(int id)
    {
        var isDelivered = _notificationService.GetNotificationDelivered(id);
        return new NotificationStatusDTO(isDelivered);
    }

    /// <summary>
    /// Send notification
    /// </summary>
    /// <param name="request">Notification</param>
    /// <returns>Notification response</returns>
    [HttpPost]
    [Route("Notify")]
    public async Task<NotificationResponseDTO> Notify(NotificationDTO request)
    {
        NotificationResponse response;

        if (request.IosNotification != null)
        {
            response = await _notificationService.SaveAndSendAsync(request.IosNotification);
        }
        else if (request.AndroidNotification != null)
        {
            response = await _notificationService.SaveAndSendAsync(request.AndroidNotification);
        }
        else
        {
            throw new ElementNotFoundException();
        }

        return new NotificationResponseDTO(response);
    }
}
