using System.Text.Json;
using RabbitMQ.Client;

namespace StudyProgramManagement.Commands.RabbitMq.Clients;

public class RabbitMqSenderClient
{
    private readonly List<string> _queues;

    public RabbitMqSenderClient(List<string> queues)
    {
        _queues = queues;
        _queues.Add("STUDY_PROGRAM_READ");
    }
    public void SendMessage(Message message) 
    {
        var factory = new ConnectionFactory { Uri = new Uri("amqp://admin:password@rabbitmq-avantys") };
        Console.WriteLine("Sending: {0}", message.Pattern);
        // Create connection to RabbitMQ server
        using (var connection = factory.CreateConnection())
        {
            // Create channel
            using (var channel = connection.CreateModel())
            {
                // Declare the queue
                _queues.ForEach(q =>
                {
                    channel.QueueDeclare(queue: q, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    // Send a message to the queue
                    var messageToSend = JsonSerializer.Serialize(message);
                    var body = System.Text.Encoding.UTF8.GetBytes(messageToSend);
                    channel.BasicPublish(exchange: "", routingKey: q, basicProperties: null, body: body);

                });
                Console.WriteLine("Message sent to the queues");
            }
        }
    }
}