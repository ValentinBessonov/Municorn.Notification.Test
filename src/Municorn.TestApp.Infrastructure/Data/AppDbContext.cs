using Microsoft.EntityFrameworkCore;
using Municorn.TestApp.Core.Models;

namespace Municorn.TestApp.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<NotificationBaseEntity> Notifications => Set<NotificationBaseEntity>();
        public DbSet<IosNotification> IosNotification => Set<IosNotification>();
        public DbSet<AndroidNotification> AndroidNotification => Set<AndroidNotification>();
    }
}
