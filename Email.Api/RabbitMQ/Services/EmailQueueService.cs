using RabbitMQ.Client;
using RabbitMQ.Models;
using RabbitMQ.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace RabbitMQ.Services
{
    public class EmailQueueService : IEmailQueueService
    {
        public async Task Publish(EmailRequest email)
        {
            var factory = new ConnectionFactory() { HostName = "localhost"};

            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            channel.QueueDeclareAsync(
                queue: "email",
                durable: false,
                exclusive: false,
                autoDelete: false);

            var mensagem = JsonSerializer.Serialize(email);
            var body = Encoding.UTF8.GetBytes(mensagem);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "email",
                body: body);
        }
    }
}
