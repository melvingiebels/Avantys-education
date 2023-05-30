using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class StudyProgramCollection: MongoCollection<StudyProgram>
{
    public StudyProgramCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}