namespace StudyProgramManagement.Commands.Commands.LectureSchedule;

public class CreateLectureScheduleCommand: CreateCommand<Domain.Models.LecturesSchedule>, ICommand
{
    public CreateLectureScheduleCommand(Domain.Models.LecturesSchedule model) : base(model)
    {
    }
}