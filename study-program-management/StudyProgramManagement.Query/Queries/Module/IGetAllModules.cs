namespace StudyProgramManagement.Query.Queries.Module;

public interface IGetAllModules
{
    IEnumerable<Domain.Models.Module> Excecute();
}