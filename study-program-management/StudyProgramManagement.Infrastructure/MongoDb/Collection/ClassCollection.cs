using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class ClassCollection : MongoCollection<ClassSchema>
{
    public ClassCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}