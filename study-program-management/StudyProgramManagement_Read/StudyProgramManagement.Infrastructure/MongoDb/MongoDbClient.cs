using MongoDB.Driver;

namespace StudyProgramManagement.Infrastructure.MongoDb;

public class MongoDbClient: MongoClient
{
    private readonly MongoClient Client;
    public IMongoDatabase Database;
    
    public MongoDbClient()
    {
        Client = new MongoClient("mongodb://root:example@mongo:27017/");
        Database = Client.GetDatabase("StudyProgramManagement");
    }       
}