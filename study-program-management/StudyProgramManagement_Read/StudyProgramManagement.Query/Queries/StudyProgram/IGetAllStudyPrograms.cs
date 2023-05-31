using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.StudyProgram;

public interface IGetAllStudyPrograms: IQuery
{
    IEnumerable<StudyProgramSchema> Excecute();
}