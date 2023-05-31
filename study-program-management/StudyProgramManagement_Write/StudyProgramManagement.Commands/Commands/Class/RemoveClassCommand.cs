namespace StudyProgramManagement.Commands.Commands.Class;

public class RemoveClassCommand: RemoveCommand, ICommand
{
    public RemoveClassCommand(Guid id) : base(id)
    {
    }
}