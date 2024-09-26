using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class TeacherModulesCollection: MongoCollection<TeacherModulesSchema>
{
    public TeacherModulesCollection(MongoDbClient mongoDb) : base(mongoDb)
    {
    }
}