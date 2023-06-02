using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StudyProgramManagement.Commands.RabbitMq.Handlers;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Infrastructure.Context;

namespace StudyProgramManagement.Commands.RabbitMq.Clients;

public class RabbitMqListenerClient
{
    private readonly string _queueName;
    private readonly IServiceScopeFactory _scopeFactory;
    private IModel? _channel;
    private IConnection? _connection;
    private EnrollmentAcceptedHandler? _enrollmentAcceptedHandler;
    private bool _isListening;
    private Thread? _listenerThread;

    public RabbitMqListenerClient(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        _queueName = "STUDY_PROGRAM_WRITE";
    }

    public void StartListening()
    {
        _isListening = true;
        _listenerThread = new Thread(ListenForMessages);
        _listenerThread.Start();
    }

    public void StopListening()
    {
        _isListening = false;
        _channel!.Close();
        _connection?.Close();
        _listenerThread?.Join();
    }

    private void ListenForMessages()
    {
        var factory = new ConnectionFactory { Uri = new Uri("amqp://admin:password@rabbitmq-avantys") };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(_queueName, false, false, false, null);
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += (model, ea) =>
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<StudyProgramManagementDbContext>();

                var body = ea.Body.ToArray();
                var messageString = Encoding.UTF8.GetString(body);
                Console.WriteLine("Message received: {0}", messageString);
                var messageObject = JsonSerializer.Deserialize<Message>(messageString);
                IsInSubscribedMessages(messageObject!, dbContext);
            }
        };

        _channel.BasicConsume(_queueName, true, consumer);

        while (_isListening)
            Thread.Sleep(100);
    }

    private void IsInSubscribedMessages(Message message, StudyProgramManagementDbContext dbContext)
    {
        if (!message.Pattern.Equals("EnrollmentAccepted")) return;
        _enrollmentAcceptedHandler = new EnrollmentAcceptedHandler(dbContext);
        var student = JsonSerializer.Deserialize<Student>(message.Data.ToString()!);
        _enrollmentAcceptedHandler.Handle(student);
    }
}