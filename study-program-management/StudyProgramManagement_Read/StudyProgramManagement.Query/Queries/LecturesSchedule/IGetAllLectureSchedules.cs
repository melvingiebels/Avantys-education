using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.LecturesSchedule;

public interface IGetAllLectureSchedules
{
    IEnumerable<LecturesScheduleSchema> Excecute();
}