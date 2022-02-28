using Microsoft.Extensions.Logging;
using Municorn.TestApp.Core.Interfaces;
using System.Text.Json;

namespace Municorn.TestApp.Infrastructure.NotificationSenders;

public class FakeNotificationSenderBase
{
    private const int DelayMin = 500;
    private const int DelayMax = 2000;

    private readonly Random _random = new();
    private readonly object atteptionlockObj = new();
    private int _attemptNumber = 0;

    public ILogger Logger { get; set; }

    public FakeNotificationSenderBase(ILogger logger)
    {
        Logger = logger;
    }

    public async Task<bool> Send(INotification notification)
    {
        Logger.LogInformation(JsonSerializer.Serialize(notification));

        await Task.Delay(_random.Next(DelayMin, DelayMax));

        bool isDelivered = true;

        lock (atteptionlockObj)
        {
            if (++_attemptNumber % 5 == 0)
            {
                isDelivered = false;
            }
        }

        return isDelivered;
    }
}
