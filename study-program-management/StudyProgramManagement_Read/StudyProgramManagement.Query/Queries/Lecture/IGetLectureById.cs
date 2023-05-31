using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Lecture;

public interface IGetLectureById: IQuery
{
    Task<LectureSchema> Excecute(Guid id);
}