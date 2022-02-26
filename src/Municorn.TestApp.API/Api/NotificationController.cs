using Microsoft.AspNetCore.Mvc;
using Municorn.TestApp.ApiModels;
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

    [HttpGet]
    [Route("NotificationStatus")]
    public NotificationStatusDTO GetNotificationStatus(int id)
    {
        var isDelivered = _notificationService.GetNotificationDelivered(id);
        return new NotificationStatusDTO(isDelivered);
    }

    [HttpPost]
    [Route("Notify")]
    public async Task<NotificationResponseDTO> Notify(INotification notification)
    {
        var response = await _notificationService.SaveAndSendAsync(notification);
        return new NotificationResponseDTO(response.Id, response.IsDelivered);
    }
}
