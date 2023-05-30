using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class LectureCollection: MongoCollection<LectureSchema>
{
    public LectureCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}