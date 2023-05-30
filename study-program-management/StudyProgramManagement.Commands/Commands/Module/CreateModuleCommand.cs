namespace StudyProgramManagement.Commands.Commands.Module;

public class CreateModuleCommand: CreateCommand<Domain.Models.Module>, ICommand
{
    public CreateModuleCommand(Domain.Models.Module model) : base(model)
    {
    }
}