using Municorn.TestApp.Core;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Infrastructure.Data;

public class AppRepository : IAppRepository
{
    private readonly AppDbContext _context;

    public AppRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateNotificationAsync<T>(T notification)
           where T : class, INotification
    {
        await _context.Set<T>().AddAsync(notification);
        await _context.SaveChangesAsync();
        return notification.Id;
    }

    public bool GetNotificationDelivered(int id)
    {
        return GetIfExist(id).IsDelivered;
    }

    public async Task UpdateNotificationStatusAsync(NotificationResponse response)
    {
        var entity = GetIfExist(response.Id);

        entity.IsDelivered = response.IsDelivered;

        await _context.SaveChangesAsync();
    }

    private NotificationBaseEntity GetIfExist(int id)
    {
        var entity = _context.Notifications.FirstOrDefault(x => x.Id.Equals(id));

        if (entity == null)
        {
            throw new ElementNotFoundException($"Notification doesn't exist! Notification id: {id}");
        }

        return entity;
    }
}
