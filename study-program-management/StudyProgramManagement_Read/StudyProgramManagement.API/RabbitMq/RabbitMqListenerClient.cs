using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.MongoDb;
using StudyProgramManagement.Read.RabbitMq.Handlers;

namespace StudyProgramManagement.Read.RabbitMq;

public class RabbitMqListenerClient
{
    private readonly string _queueName;
    private IConnection? _connection;
    private IModel? _channel;
    private Thread? _listenerThread;
    private bool _isListening;
    private readonly MongoDbClient _client;
    public RabbitMqListenerClient(MongoDbClient client, string queueName)
    {
        _client = client;
        _queueName = queueName;
    }

    public void StartListening()
    {
        _isListening = true;
        _listenerThread = new Thread(ListenForMessages);
        _listenerThread.Start();
    }
    private void ListenForMessages()
    {
        // Create connection factory
        var factory = new ConnectionFactory { Uri = new Uri("amqp://admin:password@rabbitmq-avantys")};

        // Create connection to RabbitMQ server
        _connection = factory.CreateConnection();

        // Create channel
        _channel = _connection.CreateModel();

        // Declare the queue
        _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        // Create consumer
        var consumer = new EventingBasicConsumer(_channel);

        // Define the callback for received messages
        consumer.Received += (model, ea) =>
        {
            Console.WriteLine("Hold on, message received!");
            var body = ea.Body.ToArray();
            var message = System.Text.Encoding.UTF8.GetString(body);
            var json = JsonSerializer.Deserialize<Message>(message);
            var pattern = json!.Pattern;
            Console.WriteLine("Message received: {0} : {1}", message, pattern);
            IsInSubscribedMessages(pattern, json.Data);
        };

        // Start consuming messages from the queue
        _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

        while (_isListening)
        {
            // Keep the listener thread alive
            Thread.Sleep(100);
        }
    }
    private bool IsClassEvent(string pattern, object schema)
    {
        if (!pattern.Contains("Class")) return false;
        
        var classInMessage = JsonSerializer.Deserialize<ClassSchema>(schema.ToString()!);
        switch (pattern)
        {

            case EventsCUD.ClassCreated:
                new RMQEventHandler<ClassSchema>(_client).HandleCreate(classInMessage!);
                break;
            case EventsCUD.ClassUpdated:
                new RMQEventHandler<ClassSchema>(_client).HandleUpdate(classInMessage!);
                break;
            case EventsCUD.ClassDeleted:
                new RMQEventHandler<ClassSchema>(_client).HandleDelete(classInMessage!.Id);
                break;
        } 
        return true;
    }
    private bool IsLectureEvent(string pattern, object schema)
    {
        if (!pattern.Contains("Lecture")) return false;
        var lectureInMessage = JsonSerializer.Deserialize<LectureSchema>(schema.ToString()!);
        switch (pattern)
        {
            case EventsCUD.LectureCreated:
                new RMQEventHandler<LectureSchema>(_client).HandleCreate(lectureInMessage!);
                break;
            case EventsCUD.LectureUpdated:
                new RMQEventHandler<LectureSchema>(_client).HandleUpdate(lectureInMessage!);
                break;
            case EventsCUD.LectureDeleted:
                new RMQEventHandler<LectureSchema>(_client).HandleDelete(lectureInMessage!.Id);
                break;
        }

        return true;

    }
    private bool IsLectureScheduledEvent(string pattern, object schema)
    {
        if (!pattern.Contains("LectureScheduled")) return false;
        var lectureScheduledInMessage = JsonSerializer.Deserialize<LecturesScheduleSchema>(schema.ToString()!);
        switch (pattern)
        {
            case EventsCUD.LectureScheduledCreated:
                new RMQEventHandler<LecturesScheduleSchema>(_client).HandleCreate(lectureScheduledInMessage!);
                break;
            case EventsCUD.LectureScheduledUpdated:
                new RMQEventHandler<LecturesScheduleSchema>(_client).HandleUpdate(lectureScheduledInMessage!);
                break;
            case EventsCUD.LectureScheduledDeleted:
                new RMQEventHandler<LecturesScheduleSchema>(_client).HandleDelete(lectureScheduledInMessage!.Id);
                break;
        }
        return true;

    }
    private bool IsModuleEvent(string pattern, object schema)
    {
        if (!pattern.Contains("Module")) return false;
        
        var moduleInMessage = JsonSerializer.Deserialize<ModuleSchema>(schema.ToString()!);
        switch (pattern)
        {
            case EventsCUD.ModuleCreated:
                new RMQEventHandler<ModuleSchema>(_client).HandleCreate(moduleInMessage!);
                break;
            case EventsCUD.ModuleUpdated:
                new RMQEventHandler<ModuleSchema>(_client).HandleUpdate(moduleInMessage!);
                break;
            case EventsCUD.ModuleDeleted:
                new RMQEventHandler<ModuleSchema>(_client).HandleDelete(moduleInMessage!.Id);
                break;
        }

        return true;

    }
    private bool IsStudentEvent(string pattern, object schema)
    {
        if (!pattern.Contains("Student")) return false;
        var studentInMessage = JsonSerializer.Deserialize<StudentSchema>(schema.ToString()!);
        switch (pattern)
        {
            case EventsCUD.StudentCreated:
                new RMQEventHandler<StudentSchema>(_client).HandleCreate(studentInMessage!);
                break;
            case EventsCUD.StudentUpdated:
                new RMQEventHandler<StudentSchema>(_client).HandleUpdate(studentInMessage!);
                break;
            case EventsCUD.StudentDeleted:
                new RMQEventHandler<StudentSchema>(_client).HandleDelete(studentInMessage!.Id);
                break;
        }

        return true;

    }
    private bool IsTeacherEvent(string pattern, object schema)
    {
        if (!pattern.Contains("Teacher")) return false;
        var teacherInMessage = JsonSerializer.Deserialize<TeacherSchema>(schema.ToString()!);
        switch (pattern)
        {
            case EventsCUD.TeacherCreated:
                new RMQEventHandler<TeacherSchema>(_client).HandleCreate(teacherInMessage!);
                break;
            case EventsCUD.TeacherUpdated:
                new RMQEventHandler<TeacherSchema>(_client).HandleUpdate(teacherInMessage!);
                break;
            case EventsCUD.TeacherDeleted:
                new RMQEventHandler<TeacherSchema>(_client).HandleDelete(teacherInMessage!.Id);
                break;
        }

        return true;

    }
    private bool IsTeacherModuleEvent(string pattern, object schema)
    {
        if (!pattern.Contains("TeacherModule")) return false;
        var teacherModuleInMessage = JsonSerializer.Deserialize<TeacherModulesSchema>(schema.ToString()!);
        switch (pattern)
        {
            case EventsCUD.TeacherModuleCreated:
                new RMQEventHandler<TeacherModulesSchema>(_client).HandleCreate(teacherModuleInMessage!);
                break;
            case EventsCUD.TeacherModuleUpdated:
                new RMQEventHandler<TeacherModulesSchema>(_client).HandleUpdate(teacherModuleInMessage!);
                break;
            case EventsCUD.TeacherModuleDeleted:
                new RMQEventHandler<TeacherModulesSchema>(_client).HandleDelete(teacherModuleInMessage!.Id);
                break;
        }
        return true;
    }
    private bool IsStudyProgramEvent(string pattern, object schema)
    {
        if (!pattern.Contains("StudyProgram")) return false;
        var studyProgramInMessage = JsonSerializer.Deserialize<StudyProgramSchema>(schema.ToString()!);
        switch (pattern)
        {
            case EventsCUD.StudyProgramCreated:
                new RMQEventHandler<StudyProgramSchema>(_client).HandleCreate(studyProgramInMessage!);
                break;
            case EventsCUD.StudyProgramUpdated:
                new RMQEventHandler<StudyProgramSchema>(_client).HandleUpdate(studyProgramInMessage!);
                break;
            case EventsCUD.StudyProgramDeleted:
                
                break;
        }
        return true;
    }
    private bool IsEnrollmentAcceptedEvent(string pattern, object schema)
    {
        var studentInMessage = JsonSerializer.Deserialize<StudentSchema>(schema.ToString()!);
        if (!pattern.Equals("EnrollmentAccepted")) return false;
        new RMQEventHandler<StudentSchema>(_client).HandleCreate(studentInMessage!);
        return true;

    }
    private void IsInSubscribedMessages(string pattern, object schema)
    {
        if (IsClassEvent(pattern, schema))
            return;
        if (IsLectureEvent(pattern, schema))
            return;
        if (IsLectureScheduledEvent(pattern, schema))
            return;
        if (IsModuleEvent(pattern, schema))
            return;
        if (IsStudentEvent(pattern, schema))
            return;
        if (IsTeacherEvent(pattern, schema))
            return;
        if (IsTeacherModuleEvent(pattern, schema))
            return;
        if (IsStudyProgramEvent(pattern, schema))
            return;
        if (IsStudyProgramEvent(pattern, schema))
            return;
        if (IsEnrollmentAcceptedEvent(pattern, schema))
        {
        }
        else
            Console.WriteLine("Not a valid message.");
    }
}