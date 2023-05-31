using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.StudyProgram;

public interface IGetStudyProgramById: IQuery
{
    Task<StudyProgramSchema> Excecute(Guid id);
}