using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class LectureCollection: MongoCollection<Lecture>
{
    public LectureCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}