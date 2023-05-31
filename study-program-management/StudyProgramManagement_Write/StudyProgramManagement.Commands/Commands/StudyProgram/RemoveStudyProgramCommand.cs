namespace StudyProgramManagement.Commands.Commands.StudyProgram;

public class RemoveStudyProgramCommand: RemoveCommand, ICommand
{
    public RemoveStudyProgramCommand(Guid id) : base(id)
    {
    }
}