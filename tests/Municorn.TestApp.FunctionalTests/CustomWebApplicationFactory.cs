using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Municorn.TestApp.Core.Models;
using Municorn.TestApp.Infrastructure.Data;
using System;
using System.Linq;

namespace Municorn.TestApp.FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                string inMemoryCollectionName = Guid.NewGuid().ToString();

                services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase(inMemoryCollectionName);
                        });
            });
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            var host = builder.Build();
            host.Start();

            var serviceProvider = host.Services;

            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDbContext>();

                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                try
                {
                    db.IosNotification.Add(new IosNotification()
                    {
                        PushToken = "some pushToken",
                        Alert = "some alert"           
                    });

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred seeding the " +
                                        "database with test messages. Error: {exceptionMessage}", ex.Message);
                }
            }

            return host;
        }
    }
}