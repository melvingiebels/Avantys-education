namespace StudyProgramManagement.Query.Queries.StudyProgram;

public interface IGetStudyProgramById
{
    Task<Domain.Models.StudyProgram> Excecute(Guid id);
}