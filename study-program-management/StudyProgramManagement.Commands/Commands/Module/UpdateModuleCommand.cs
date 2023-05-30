namespace StudyProgramManagement.Commands.Commands.Module;

public class UpdateModuleCommand: UpdateCommand<Domain.Models.Module>, ICommand
{
    public UpdateModuleCommand(Domain.Models.Module model) : base(model)
    {
    }
}