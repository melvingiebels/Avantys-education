using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.TeacherModules;

public interface IGetTeacherModuleById: IQuery
{
    Task<TeacherModulesSchema> Excecute(Guid id);
}