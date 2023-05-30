namespace StudyProgramManagement.Commands.Commands.Student;

public class RemoveStudentCommand: RemoveCommand, ICommand
{
    public RemoveStudentCommand(Guid id) : base(id)
    {
    }
}