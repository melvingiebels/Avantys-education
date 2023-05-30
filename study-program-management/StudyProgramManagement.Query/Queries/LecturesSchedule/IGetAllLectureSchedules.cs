namespace StudyProgramManagement.Query.Queries.LecturesSchedule;

public interface IGetAllLectureSchedules
{
    IEnumerable<Domain.Models.LecturesSchedule> Excecute();
}