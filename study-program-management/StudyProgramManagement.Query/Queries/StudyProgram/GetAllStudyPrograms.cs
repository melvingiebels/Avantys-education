namespace StudyProgramManagement.Query.Queries.StudyProgram;

public interface GetAllStudyPrograms
{
    IEnumerable<Domain.Models.StudyProgram> Excecute();
}