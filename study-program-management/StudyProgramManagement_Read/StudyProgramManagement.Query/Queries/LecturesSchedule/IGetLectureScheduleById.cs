using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.LecturesSchedule;

public interface IGetLectureScheduleById: IQuery
{
    Task<LecturesScheduleSchema> Excecute(Guid id);
}