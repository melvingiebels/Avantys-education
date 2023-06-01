using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Commands.LectureSchedule;

public class UpdateLectureScheduleCommand : UpdateCommand<LecturesSchedule>, ICommand
{
    public UpdateLectureScheduleCommand(LecturesSchedule model) : base(model)
    {
    }
}