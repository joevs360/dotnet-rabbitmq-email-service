namespace RabbitMQ_Consumer;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
        };

        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(
            queue: "email",
            durable: false,
            exclusive: false,
            autoDelete: false);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine("Email recebido:");
            Console.WriteLine(message);

            //Simular processamento
            Thread.Sleep(2000);

            Console.WriteLine("Email processado!");
        };

        await channel.BasicConsumeAsync(
            queue: "email",
            autoAck: true,
            consumer: consumer);
    }
}
