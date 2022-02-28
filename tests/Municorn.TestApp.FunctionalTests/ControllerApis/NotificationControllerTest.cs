using Municorn.TestApp.ApiModels;
using Municorn.TestApp.Core.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Municorn.TestApp.FunctionalTests.ControllerApis
{
    public class NotificationControllerTest: IClassFixture<CustomWebApplicationFactory<WebMarker>>
    {
        private HttpClient _client;

        public NotificationControllerTest(CustomWebApplicationFactory<WebMarker> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsNotOkWhenNotifyNothing()
        {
            var response = await _client.PostAsJsonAsync("/Notify", new NotificationDTO());

            Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsBadRequestWhenNotifyWithValidateError()
        {
            var response = await _client.PostAsJsonAsync("/Notify", new NotificationDTO
            {
                IosNotification = new IosNotification()
                {
                    Alert = "some alert",
                    PushToken = "0123456789|0123456789|0123456789|0123456789|0123456789|",
                }
            });

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsNotificationResponseWhenNotifyIos()
        {
            var response = await _client.PostAsJsonAsync("/Notify", new NotificationDTO
            {
                IosNotification = new IosNotification()
                {
                    Alert = "some alert",
                    PushToken = "some token",
                }
            });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var notificationResponse = await response.Content.ReadAsAsync<NotificationResponseDTO>();

            Assert.NotNull(notificationResponse);
            Assert.NotNull(notificationResponse.NotificationStatus);
            Assert.NotEqual(0, notificationResponse.NotificationId);
        }

        [Fact]
        public async Task ReturnsNotificationResponseWhenNotifyAndroid()
        {
            var response = await _client.PostAsJsonAsync("/Notify", new NotificationDTO
            {
                AndroidNotification = new AndroidNotification()
                {
                    Title = "some alert",
                    Message = "some token",
                    DeviceToken = "some token"
                }
            });

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var notificationResponse = await response.Content.ReadAsAsync<NotificationResponseDTO>();

            Assert.NotNull(notificationResponse);
            Assert.NotNull(notificationResponse.NotificationStatus);
            Assert.NotEqual(0, notificationResponse.NotificationId);
        }


        [Fact]
        public async Task ReturnsNotificationStatus()
        {
            var response = await _client.GetAsync("NotificationStatus?id=1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var status = await response.Content.ReadAsAsync<NotificationStatusDTO>();

            Assert.NotNull(status);
        }

        [Fact]
        public async Task ReturnsNotFound()
        {
            var response = await _client.GetAsync("NotificationStatus?id=100");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
