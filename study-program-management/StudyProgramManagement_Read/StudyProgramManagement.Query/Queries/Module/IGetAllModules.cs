using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Module;

public interface IGetAllModules: IQuery
{
    IEnumerable<ModuleSchema> Excecute();
}