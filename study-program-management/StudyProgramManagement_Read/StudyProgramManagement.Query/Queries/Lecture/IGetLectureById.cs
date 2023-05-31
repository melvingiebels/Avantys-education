using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Lecture;

public interface IGetLectureById
{
    Task<LectureSchema> Excecute(Guid id);
}