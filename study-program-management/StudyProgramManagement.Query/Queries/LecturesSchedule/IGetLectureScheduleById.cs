using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.LecturesSchedule;

public interface IGetLectureScheduleById
{
    Task<LecturesScheduleSchema> Excecute(Guid id);
}