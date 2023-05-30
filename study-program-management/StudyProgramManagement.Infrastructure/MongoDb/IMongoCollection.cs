using MongoDB.Driver;

namespace StudyProgramManagement.Infrastructure.MongoDb;

public abstract class MongoCollection<TDocument>
{
   public IMongoCollection<TDocument> Collection;

   protected MongoCollection(IMongoDatabase mongoDb)
   {
      Collection = mongoDb.GetCollection<TDocument>($"{typeof(TDocument)}");
   }
}