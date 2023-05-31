using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.TeacherModules;

public interface IGetAllTeacherModules: IQuery
{
    IEnumerable<TeacherModulesSchema> Excecute();
}