namespace Municorn.TestApp.Core.NotificationSenders
{
    public class FakeNotificationSenderBase
    {
        private const int DelayMin = 500;
        private const int DelayMax = 2000;
        
        private readonly Random _random;

        public FakeNotificationSenderBase()
        {
            _random = new Random();
        }

        public async Task<int> Send()
        {
            await Task.Delay(_random.Next(DelayMin, DelayMax));

            // return id
            return 1;
        }
    }
}
