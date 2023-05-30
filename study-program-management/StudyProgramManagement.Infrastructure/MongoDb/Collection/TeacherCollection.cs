using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class TeacherCollection: MongoCollection<Teacher>
{
    public TeacherCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}