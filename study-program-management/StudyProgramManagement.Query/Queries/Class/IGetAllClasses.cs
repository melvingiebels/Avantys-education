namespace StudyProgramManagement.Query.Queries.Class;

public interface IGetAllClasses: IQuery
{
    IEnumerable<Domain.Models.Class> Excecute();
}