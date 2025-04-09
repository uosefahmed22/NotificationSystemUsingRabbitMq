using NotificationSystemUsingRabbitMq.Models;

namespace NotificationSystemUsingRabbitMq.Services
{
    public interface IRabbitMQService
    {
        void PublishMessage(NotificationMessage message);
        void StartConsuming();
    }
}
