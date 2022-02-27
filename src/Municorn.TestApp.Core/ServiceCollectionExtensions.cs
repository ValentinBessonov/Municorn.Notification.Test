using Microsoft.Extensions.DependencyInjection;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;
using Municorn.TestApp.Core.NotificationSenders;
using Municorn.TestApp.Core.Services;

namespace Municorn.TestApp.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationSender<IosNotification>, IosNotificationSender>();
            services.AddScoped<INotificationSender<AndroidNotification>, AndroidNotificationSender>();
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}
