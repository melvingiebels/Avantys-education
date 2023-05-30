using MongoDB.Driver;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.LecturesSchedule;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.LectureSchedule;

public class GetLectureSchedulesByIdHandler: MongoQueryBase<LectureScheduleCollection>, IGetLectureScheduleById
{
    public GetLectureSchedulesByIdHandler(LectureScheduleCollection collection) : base(collection)
    {
    }

    public async Task<Domain.Models.LecturesSchedule> Excecute(Guid id)
    {
        var filter = Builders<Domain.Models.LecturesSchedule>.Filter
            .Eq(r => r.Id, id);
        return await Collection.Collection.Find(filter).FirstOrDefaultAsync();
    }
}