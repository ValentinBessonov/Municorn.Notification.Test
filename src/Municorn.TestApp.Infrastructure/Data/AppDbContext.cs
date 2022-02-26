using Microsoft.EntityFrameworkCore;
using Municorn.TestApp.Infrastructure.Data.Entities;

namespace Municorn.TestApp.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<NotificationBase> Notifications => Set<NotificationBase>();
        public DbSet<IosNotification> IosNotification => Set<IosNotification>();
        public DbSet<AndroidNotification> AndroidNotification => Set<AndroidNotification>();
    }
}
