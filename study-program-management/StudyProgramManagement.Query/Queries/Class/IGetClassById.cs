namespace StudyProgramManagement.Query.Queries.Class;

public interface IGetClassById
{
    Task<Domain.Models.Class> Excecute(Guid id);
}