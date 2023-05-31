using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Module;

public interface IGetModuleById
{
    Task<ModuleSchema> Excecute(Guid id);
}