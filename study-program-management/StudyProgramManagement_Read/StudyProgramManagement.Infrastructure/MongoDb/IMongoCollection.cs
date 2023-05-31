using MongoDB.Driver;

namespace StudyProgramManagement.Infrastructure.MongoDb;

public abstract class MongoCollection<TDocument>
{
   public readonly MongoDbClient MongoClient;
   public readonly IMongoDatabase Database;
   public readonly IMongoCollection<TDocument> Collection;

   protected MongoCollection(MongoDbClient mongoClient)
   {
      MongoClient = mongoClient;
      Database = MongoClient.GetDatabase("StudyProgramManagement");
      Collection = MongoClient.Database.GetCollection<TDocument>($"{typeof(TDocument)}");
   }
}