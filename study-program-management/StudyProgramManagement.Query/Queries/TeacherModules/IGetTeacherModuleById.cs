namespace StudyProgramManagement.Query.Queries.TeacherModules;

public interface IGetTeacherModuleById
{
    Task<Domain.Models.TeacherModules> Excecute(Guid id);
}