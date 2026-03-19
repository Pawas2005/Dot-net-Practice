using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CustomerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            // Connect to RabbitMQ (Using 'await using' ensures proper cleanup on termination)
            await using var connection = await factory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            // Ensure the queue exists
            await channel.QueueDeclareAsync(
                queue: "orderQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            _logger.LogInformation("Waiting for orders...");

            // Create a consumer
            var consumer = new AsyncEventingBasicConsumer(channel);

            // Define what happens when a message is received
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation("Order Received: {Message}", message);

                // Process the order here...

                await Task.CompletedTask;
            };

            // Start consuming
            await channel.BasicConsumeAsync(
                queue: "orderQueue",
                autoAck: true,
                consumer: consumer
            );

            // Keep the worker running without busy-waiting
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
            }
            catch (TaskCanceledException)
            {
                // Task was canceled because service is shutting down
            }
        }
    }
}