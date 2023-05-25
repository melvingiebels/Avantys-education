using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    const string exchangeName = "DemoExchange";
    const string routingKey = "demo-routing-key";
    const string message = "Hello, World!";

    var body = Encoding.UTF8.GetBytes(message);

    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
    channel.BasicPublish(exchangeName, routingKey, null, body);
    Console.WriteLine("Message sent: {0}", message);
}