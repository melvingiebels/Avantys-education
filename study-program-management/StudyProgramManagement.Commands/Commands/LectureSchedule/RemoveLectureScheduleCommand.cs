namespace StudyProgramManagement.Commands.Commands.LectureSchedule;

public class RemoveLectureScheduleCommand: RemoveCommand, ICommand
{
    public RemoveLectureScheduleCommand(Guid id) : base(id)
    {
    }
}