using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Module;

public interface IGetModuleById: IQuery
{
    Task<ModuleSchema> Excecute(Guid id);
}