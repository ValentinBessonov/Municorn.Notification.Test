namespace Municorn.TestApp.Core.Interfaces
{
    public interface INotification
    {
        int Id { get; set; }
        bool IsDelivered { get; set; }
    }
}
