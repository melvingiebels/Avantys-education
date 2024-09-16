using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class LectureCollection: MongoCollection<LectureSchema>
{
    public LectureCollection(MongoDbClient mongoDb) : base(mongoDb)
    {
    }
}