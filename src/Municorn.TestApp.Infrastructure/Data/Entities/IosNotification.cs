using System.ComponentModel.DataAnnotations;

namespace Municorn.TestApp.Infrastructure.Data.Entities;

public class IosNotification : NotificationBase
{
    [Required]
    [MaxLength(50)]
    public string PushToken { get; set; }

    [Required]
    [MaxLength(2000)]
    public string Alert { get; set; }

    public int Priority { get; set; }

    public bool IsBackground { get; set; }

    public IosNotification(Core.Models.IosNotification notification)
    {
        PushToken = notification.PushToken;
        Alert = notification.Alert;
        Priority = notification.Priority;
        Priority = notification.Priority;
        IsBackground = notification.IsBackground;
    }

    public IosNotification()
    {

    }
}
