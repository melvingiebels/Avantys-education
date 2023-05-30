using MongoDB.Driver;
using StudyProgramManagement.Domain.Models;
using StudyProgramManagement.Domain.Schemas;
using StudyProgramManagement.Infrastructure.Core;
using StudyProgramManagement.Infrastructure.MongoDb.Collection;
using StudyProgramManagement.Query.Queries.LecturesSchedule;

namespace StudyProgramManagement.Infrastructure.Handlers.QueryHandler.LectureSchedule;

public class GetAllLectureSchedulesHandler: MongoQueryBase<LectureScheduleCollection>, IGetAllLectureSchedules
{
    public GetAllLectureSchedulesHandler(LectureScheduleCollection collection) : base(collection)
    {
    }

    public IEnumerable<LecturesScheduleSchema> Excecute()
    {
        return Collection.Collection.Find(p => true).ToList();
    }
}