using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.StudyProgram;

public interface IGetStudyProgramById
{
    Task<StudyProgramSchema> Excecute(Guid id);
}