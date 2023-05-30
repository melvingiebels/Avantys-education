using MongoDB.Driver;

namespace StudyProgramManagement.Infrastructure.MongoDb;

public class MongoDbClient
{
    private readonly MongoClient Client;
    public IMongoDatabase Database;
    
    public MongoDbClient()
    {
        Client = new MongoClient("mongodb://localhost:27017");
        Database = Client.GetDatabase("StudyProgramManagement");
    }       
}