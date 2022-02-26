using Microsoft.Extensions.DependencyInjection;
using Municorn.TestApp.Core.Models;
using Municorn.TestApp.Core.NotificationSenders;

namespace Municorn.TestApp.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCommonHostedServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationSender<IosNotification>, IosNotificationSender>();
            services.AddScoped<INotificationSender<AndroidNotification>, AndroidNotificationSender>();

            return services;
        }
    }
}
