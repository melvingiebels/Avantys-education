using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class ClassCollection : MongoCollection<ClassSchema>
{
    public ClassCollection(MongoDbClient mongoDb) : base(mongoDb)
    {
    }
}