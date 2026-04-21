using RabbitMQ.Models;

namespace RabbitMQ.Services.Interfaces
{
    public interface IEmailQueueService
    {
         Task Publish(EmailRequest email);
    }
}
