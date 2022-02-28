using Municorn.TestApp.Core.Interfaces;
using System.Text.Json.Serialization;

namespace Municorn.TestApp.Core.Models;

public abstract class NotificationBaseEntity: INotification
{
    [JsonIgnore]
    public int Id { get; set; }

    [JsonIgnore]
    public bool IsDelivered { get; set; }
}
