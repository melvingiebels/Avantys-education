using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class LectureScheduleCollection: MongoCollection<LecturesSchedule>
{
    public LectureScheduleCollection(IMongoDatabase mongoDb) : base(mongoDb)
    {
    }
}