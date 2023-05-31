using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Class;

public interface IGetClassById
{
    Task<ClassSchema> Excecute(Guid id);
}