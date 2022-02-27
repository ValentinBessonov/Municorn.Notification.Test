using Municorn.TestApp.Core;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Infrastructure.Data.Entities;

namespace Municorn.TestApp.Infrastructure.Data;

public class AppRepository : IAppRepository
{
    private readonly AppDbContext _context;

    public AppRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateNotificationAsync(Core.Models.IosNotification notification)
    {
        var entity = new IosNotification(notification);

        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task<int> CreateNotificationAsync(Core.Models.AndroidNotification notification)
    {
        var entity = new AndroidNotification(notification);

        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public bool GetNotificationDelivered(int id)
    {
        return GetIfExist(id).IsDelivered;
    }

    public async Task UpdateNotificationStatusAsync(Core.Models.NotificationResponse response)
    {
        var entity = GetIfExist(response.Id);

        entity.IsDelivered = response.IsDelivered;

        await _context.SaveChangesAsync();
    }

    private NotificationBase GetIfExist(int id)
    {
        var entity = _context.Notifications.FirstOrDefault(x => x.Id.Equals(id));

        if (entity == null)
        {
            throw new ElementNotFoundException($"Notification doesn't exist! Notification id: {id}");
        }

        return entity;
    }
}
