using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Infrastructure.Data.Entities;

namespace Municorn.TestApp.Infrastructure.Data;

public class AppRepository : IAppRepository
{
    private AppDbContext _context;

    public AppRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateNotificationAsync(Core.Models.IosNotification notification)
    {
        var en = new IosNotification(notification);

        _context.Add(en);
        await _context.SaveChangesAsync();

        return en.Id;
    }

    public async Task<int> CreateNotificationAsync(Core.Models.AndroidNotification notification)
    {
        var en = new AndroidNotification(notification);

        _context.Add(en);
        await _context.SaveChangesAsync();

        return en.Id;
    }

    public bool GetNotificationDelivered(int id)
    {
        return _context.Notifications.First(x => x.Id.Equals(id)).IsDelivered;
    }

    public async Task UpdateNotificationStatusAsync(Core.Models.NotificationResponse response)
    {
        var entity = _context.Notifications.First(x => x.Id.Equals(response));

        entity.IsDelivered = response.IsDelivered;

        await _context.SaveChangesAsync();
    }
}
