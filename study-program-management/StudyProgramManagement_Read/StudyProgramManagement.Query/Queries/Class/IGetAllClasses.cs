using StudyProgramManagement.Domain.Schemas;

namespace StudyProgramManagement.Query.Queries.Class;

public interface IGetAllClasses: IQuery
{
    IEnumerable<ClassSchema> Excecute();
}