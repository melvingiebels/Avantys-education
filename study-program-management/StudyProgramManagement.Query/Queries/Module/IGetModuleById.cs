namespace StudyProgramManagement.Query.Queries.Module;

public interface IGetModuleById
{
    Task<Domain.Models.Module> Excecute(Guid id);
}