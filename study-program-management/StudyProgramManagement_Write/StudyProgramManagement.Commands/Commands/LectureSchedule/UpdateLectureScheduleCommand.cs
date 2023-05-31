namespace StudyProgramManagement.Commands.Commands.LectureSchedule;

public class UpdateLectureScheduleCommand: UpdateCommand<Domain.Models.LecturesSchedule>, ICommand
{
    public UpdateLectureScheduleCommand(Domain.Models.LecturesSchedule model) : base(model)
    {
    }
}