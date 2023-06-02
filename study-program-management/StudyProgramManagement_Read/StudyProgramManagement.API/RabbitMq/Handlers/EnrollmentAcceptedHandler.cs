using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.MongoDb;

namespace StudyProgramManagement.Read.RabbitMq.Handlers;

public class EnrollmentAcceptedHandler: RabbitMqEventHandler<StudentSchema>
{
    private readonly IMongoDatabase _database;
    
    public EnrollmentAcceptedHandler(MongoDbClient client)
    {
        _database = client.Database;
    }

    public override void Handle(StudentSchema? schema)
    {
        var collection = _database.GetCollection<StudentSchema>("StudentSchema");
        collection.InsertOne(schema);
    }
}