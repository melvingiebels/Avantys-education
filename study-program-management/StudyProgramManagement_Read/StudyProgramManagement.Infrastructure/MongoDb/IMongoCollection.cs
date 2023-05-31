using MongoDB.Driver;

namespace StudyProgramManagement.Infrastructure.MongoDb;

public abstract class MongoCollection<TDocument>
{
   private readonly MongoDbClient MongoClient;
   public readonly IMongoCollection<TDocument> Collection;

   protected MongoCollection(MongoDbClient mongoClient)
   {
      MongoClient = mongoClient;
      Collection = MongoClient.Database.GetCollection<TDocument>($"{typeof(TDocument)}");
   }
}