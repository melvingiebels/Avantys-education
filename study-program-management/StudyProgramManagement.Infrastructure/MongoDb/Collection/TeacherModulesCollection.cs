using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class TeacherModulesCollection: MongoCollection<TeacherModules>
{
    public TeacherModulesCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}