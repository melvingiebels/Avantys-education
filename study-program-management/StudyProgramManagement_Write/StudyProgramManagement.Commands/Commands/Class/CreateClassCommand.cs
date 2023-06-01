namespace StudyProgramManagement.Commands.Commands.Class;

public class CreateClassCommand : CreateCommand<Domain.Models.Class>, ICommand
{
    public CreateClassCommand(Domain.Models.Class model) : base(model)
    {
    }
}