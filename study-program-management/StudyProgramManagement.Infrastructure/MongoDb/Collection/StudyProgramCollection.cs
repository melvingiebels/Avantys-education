using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class StudyProgramCollection: MongoCollection<StudyProgramSchema>
{
    public StudyProgramCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}