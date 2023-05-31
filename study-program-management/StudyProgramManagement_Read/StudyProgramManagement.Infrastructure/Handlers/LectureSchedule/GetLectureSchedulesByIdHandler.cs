using MongoDB.Driver;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.LecturesSchedule;

namespace StudyProgramManagement.Infrastructure.Handlers.LectureSchedule;

public class GetLectureSchedulesByIdHandler: MongoQueryBase<LectureScheduleCollection>, IGetLectureScheduleById
{
    public GetLectureSchedulesByIdHandler(LectureScheduleCollection collection) : base(collection)
    {
    }

    public async Task<LecturesScheduleSchema> Excecute(Guid id)
    {
        var filter = Builders<LecturesScheduleSchema>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}