namespace StudyProgramManagement.Commands.Commands.Teacher;

public class RemoveTeacherCommand: RemoveCommand, ICommand
{
    public RemoveTeacherCommand(Guid id) : base(id)
    {
    }
}