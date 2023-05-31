using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace StudyProgramManagement.RabbitMQ;

public class RabbitMqListenerClient
{
    private readonly ConnectionFactory _factory;
    private readonly string? _queueName;
    private readonly string? _routingKey;
    private readonly string? _exchangeName;

    public RabbitMqListenerClient(IConfiguration configuration)
    {
        var configSection = configuration.GetSection("RabbitMQ");
        _factory = new ConnectionFactory
        {
            Uri = new Uri(configuration.GetConnectionString("RabbitMQ")!),
            ClientProvidedName = "TestManagement"
        };
        _exchangeName = configSection.GetSection("ExchangeName").Value;
        _queueName = configSection.GetSection("QueueName").Value;
        _routingKey = configSection.GetSection("RoutingKey").Value;
    }

    public void Listen()
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
        channel.QueueDeclare(_queueName, false, false, false, null);
        channel.QueueBind(_queueName, _exchangeName, _routingKey, null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (sender, args) =>
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("Message received: {0}", message);
            channel.BasicAck(args.DeliveryTag, false);
        };

        channel.BasicConsume(_queueName, false, consumer);

        Console.WriteLine("Listening for messages. Press any key to exit...");
        Console.ReadKey();
    }
}