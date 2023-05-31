using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class StudyProgramCollection: MongoCollection<StudyProgramSchema>
{
    public StudyProgramCollection(MongoDbClient mongoDb) : base(mongoDb)
    {
    }
}