using Microsoft.Extensions.DependencyInjection;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Services;

namespace Municorn.TestApp.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services) => services
            .AddScoped<INotificationService, NotificationService>();
    }
}
