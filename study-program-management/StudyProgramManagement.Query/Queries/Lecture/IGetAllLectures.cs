namespace StudyProgramManagement.Query.Queries.Lecture;

public interface IGetAllLectures
{
    IEnumerable<Domain.Models.Lecture> Excecute();
}