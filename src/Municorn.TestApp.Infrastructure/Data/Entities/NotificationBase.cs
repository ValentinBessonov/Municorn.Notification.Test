namespace Municorn.TestApp.Infrastructure.Data.Entities;

public abstract class NotificationBase
{
    public int Id { get; set; }
    public bool IsDelivered { get; set; }
}
