namespace StudyProgramManagement.Commands.Commands;

public class RemoveCommand
{
    public Guid Id;

    public RemoveCommand(Guid id)
    {
        Id = id;
    }
}