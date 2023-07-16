using MassTransit;

namespace APIIntegration.Infrastructure.IntegrationEvents
{
    public class ApiIntegrationEvent : IApiIntegrationEvent
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ApiIntegrationEvent(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task PublishIntegrationEvent<T>(T integrationEvent) where T: class
        {
            await _publishEndpoint.Publish(integrationEvent);
        }
    }
}
