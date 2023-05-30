using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class LectureScheduleCollection: MongoCollection<LecturesScheduleSchema>
{
    public LectureScheduleCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}