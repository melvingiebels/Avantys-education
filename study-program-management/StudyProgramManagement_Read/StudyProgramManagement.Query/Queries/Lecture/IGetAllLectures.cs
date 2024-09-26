using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Lecture;

public interface IGetAllLectures: IQuery
{
    IEnumerable<LectureSchema> Excecute();
}