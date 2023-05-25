using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    const string exchangeName = "my-exchange";
    const string routingKey = "my-routing-key";
    const string queueName = "my-queue";

    channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
    channel.QueueDeclare(queueName, false, false, false, null);
    channel.QueueBind(queueName, exchangeName, routingKey, null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (sender, args) =>
    {
        var body = args.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Message received: {0}", message);
        channel.BasicAck(args.DeliveryTag, false);
    };

    channel.BasicConsume(queueName, false, consumer);

    Console.WriteLine("Listening for messages. Press any key to exit...");
    Console.ReadKey();
}