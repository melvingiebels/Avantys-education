using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Infrastructure.MongoDb.Collection;

public class LectureScheduleCollection: MongoCollection<LecturesScheduleSchema>
{
    public LectureScheduleCollection(MongoDbClient mongoDb) : base(mongoDb)
    {
    }
}