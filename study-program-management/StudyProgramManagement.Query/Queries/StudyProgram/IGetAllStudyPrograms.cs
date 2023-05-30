using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.StudyProgram;

public interface IGetAllStudyPrograms
{
    IEnumerable<StudyProgramSchema> Excecute();
}