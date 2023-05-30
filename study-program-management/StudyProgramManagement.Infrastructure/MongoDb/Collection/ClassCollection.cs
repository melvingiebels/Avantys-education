using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class ClassCollection : MongoCollection<Class>
{
    public ClassCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}