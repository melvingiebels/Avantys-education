using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.MongoDb;

namespace StudyProgramManagement.Read.RabbitMq.Handlers;

public class RMQEventHandler<TSchema> where TSchema : Schema
{
    private readonly IMongoDatabase _database;
    
    public RMQEventHandler(MongoDbClient client)
    {
        _database = client.Database;
    }
    
    public void HandleCreate(TSchema model)
    {
        var collection = _database.GetCollection<TSchema>($"{typeof(TSchema).Name}");
        collection.InsertOne(model);
    }
    
    public void HandleUpdate(TSchema model)
    {
        var collection = _database.GetCollection<TSchema>($"{typeof(TSchema).Name}");
        var filter = Builders<TSchema>.Filter
            .Eq(r => r.Id, model!.Id);

        collection.DeleteOne(filter);
    }

    public void HandleDelete(Guid modelId)
    {
        var collection = _database.GetCollection<TSchema>($"{typeof(TSchema).Name}");
        var filter = Builders<TSchema>.Filter
            .Eq(r => r.Id, modelId);

        collection.DeleteOne(filter);
    }
}