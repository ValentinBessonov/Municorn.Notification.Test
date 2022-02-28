using Microsoft.Extensions.Logging;
using Moq;
using Municorn.TestApp.Core.Models;
using Municorn.TestApp.Infrastructure.NotificationSenders;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Municorn.TestApp.IntegrationTests.Senders
{
    public class FakeSenderTests
    {
        private IosNotification iosNotification = new()
        {
            Alert = "some alert",
            PushToken = "token"
        };

        [Fact]
        public async Task EveryFiveNotDelivered()
        {
            var sender = new FakeNotificationSender(new Mock<ILogger>().Object);

            foreach (var attemptNumber in Enumerable.Range(1, 10))
            {
                var isDelivered = await sender.Send(iosNotification);
                if (attemptNumber % 5 == 0)
                {
                    Assert.False(isDelivered);
                }
                else
                {
                    Assert.True(isDelivered);
                }
            }
        }

        [Fact]
        public void EveryFiveNotDeliveredParallel()
        {
            var sender = new FakeNotificationSender(new Mock<ILogger>().Object);
            var count = 50;

            var attemps = Enumerable.Range(0, count);

            var res = attemps.AsParallel().Select(x => sender.Send(iosNotification).GetAwaiter().GetResult());

            Assert.Equal(count / 5, res.Where(isDelivered => isDelivered == false).Count());
        }
    }
}
