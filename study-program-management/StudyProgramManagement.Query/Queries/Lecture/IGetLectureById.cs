namespace StudyProgramManagement.Query.Queries.Lecture;

public interface IGetLectureById
{
    Task<Domain.Models.Lecture> Excecute(Guid id);
}