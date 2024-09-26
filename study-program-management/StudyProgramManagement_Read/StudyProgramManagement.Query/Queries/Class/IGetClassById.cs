using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Class;

public interface IGetClassById: IQuery
{
    Task<ClassSchema> Excecute(Guid id);
}