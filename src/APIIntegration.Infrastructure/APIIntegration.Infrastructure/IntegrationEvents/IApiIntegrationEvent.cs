namespace APIIntegration.Infrastructure.IntegrationEvents
{
    public interface IApiIntegrationEvent
    {
        Task PublishIntegrationEvent<T>(T integrationEvent) where T : class;
    }
}
