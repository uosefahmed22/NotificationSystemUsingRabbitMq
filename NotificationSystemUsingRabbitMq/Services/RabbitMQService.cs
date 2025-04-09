using NotificationSystemUsingRabbitMq.Models;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;

namespace NotificationSystemUsingRabbitMq.Services
{

    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory
            {
                HostName = RabbitMQConfig.HostName
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(RabbitMQConfig.QueueName, false, false, false, null);
        }

        public void PublishMessage(NotificationMessage message)
        {
            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(
                exchange: "",
                routingKey: RabbitMQConfig.QueueName,
                basicProperties: null,
                body: body);
        }

        public void StartConsuming()
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var notificationMessage = JsonSerializer.Deserialize<NotificationMessage>(message);

                Console.WriteLine($"Received message: {notificationMessage.Type} - {notificationMessage.Message}");
            };

            _channel.BasicConsume(queue: RabbitMQConfig.QueueName,
                                autoAck: true,
                                consumer: consumer);
        }
    }
}
