using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class TeacherCollection: MongoCollection<TeacherSchema>
{
    public TeacherCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}