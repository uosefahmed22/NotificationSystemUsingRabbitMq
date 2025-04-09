namespace NotificationSystemUsingRabbitMq.Models
{
    public class NotificationMessage
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
