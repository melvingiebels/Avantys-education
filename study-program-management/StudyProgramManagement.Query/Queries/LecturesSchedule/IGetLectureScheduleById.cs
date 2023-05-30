namespace StudyProgramManagement.Query.Queries.LecturesSchedule;

public interface IGetLectureScheduleById
{
    Task<Domain.Models.LecturesSchedule> Excecute(Guid id);
}