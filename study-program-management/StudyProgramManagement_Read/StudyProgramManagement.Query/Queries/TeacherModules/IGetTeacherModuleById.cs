using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.TeacherModules;

public interface IGetTeacherModuleById
{
    Task<TeacherModulesSchema> Excecute(Guid id);
}