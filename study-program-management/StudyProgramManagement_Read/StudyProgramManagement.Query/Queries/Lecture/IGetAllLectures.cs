using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Lecture;

public interface IGetAllLectures
{
    IEnumerable<LectureSchema> Excecute();
}