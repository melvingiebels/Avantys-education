namespace StudyProgramManagement.Commands.Commands.Class;

public class UpdateClassCommand: UpdateCommand<Domain.Models.Class>, ICommand
{
    public UpdateClassCommand(Domain.Models.Class model) : base(model)
    {
    }
}