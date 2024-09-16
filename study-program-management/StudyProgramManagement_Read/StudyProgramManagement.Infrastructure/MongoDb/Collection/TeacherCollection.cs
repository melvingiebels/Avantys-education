using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class TeacherCollection: MongoCollection<TeacherSchema>
{
    public TeacherCollection(MongoDbClient mongoDb) : base(mongoDb)
    {
    }
}