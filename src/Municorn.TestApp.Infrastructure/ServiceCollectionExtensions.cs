using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Municorn.TestApp.Core.Interfaces;
using Municorn.TestApp.Core.Models;
using Municorn.TestApp.Infrastructure.Data;
using Municorn.TestApp.Infrastructure.NotificationSenders;

namespace Municorn.TestApp.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) => services
            .AddSingleton<INotificationSender<IosNotification>, IosNotificationSender>()
            .AddSingleton<INotificationSender<AndroidNotification>, AndroidNotificationSender>();

    public static void AddRepositories(this IServiceCollection services) => services
        .AddScoped<IAppRepository, AppRepository>();

    public static void AddDbContext(this IServiceCollection services, string connectionString) => services
        .AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

    public static void AddDbContext(this IServiceCollection services) => services
        .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("Municorn.TestApp"));
}
