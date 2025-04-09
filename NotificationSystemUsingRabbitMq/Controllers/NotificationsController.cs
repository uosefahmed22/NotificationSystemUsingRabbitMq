using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationSystemUsingRabbitMq.Models;
using NotificationSystemUsingRabbitMq.Services;

namespace NotificationSystemUsingRabbitMq.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;

        public NotificationsController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [HttpPost]
        public IActionResult SendNotification([FromBody] NotificationMessage message)
        {
            message.Timestamp = DateTime.UtcNow;
            _rabbitMQService.PublishMessage(message);
            return Ok("Message published successfully");
        }
    }
}
