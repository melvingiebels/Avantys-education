using System.Text;
using RabbitMQ.Client;

namespace TestManagement.RabbitMQ;

public class RabbitMqSenderClient
{
    private readonly ConnectionFactory _factory;
    private readonly string? _queueName;
    private readonly string? _routingKey;
    private readonly string? _exchangeName;

    public RabbitMqSenderClient(IConfiguration configuration)
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

    public void SendMessage(string message)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();

        var body = Encoding.UTF8.GetBytes(message);

        channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct);
        channel.BasicPublish(_exchangeName, _routingKey, null, body);
        Console.WriteLine("Message sent: {0}", message);
    }
}