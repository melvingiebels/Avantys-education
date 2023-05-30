using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class TeacherModulesCollection: MongoCollection<TeacherModulesSchema>
{
    public TeacherModulesCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}