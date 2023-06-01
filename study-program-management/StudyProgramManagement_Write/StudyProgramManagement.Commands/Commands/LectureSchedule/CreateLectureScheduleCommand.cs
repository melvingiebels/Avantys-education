using StudyProgramManagement.Domain.Models;

namespace StudyProgramManagement.Commands.Commands.LectureSchedule;

public class CreateLectureScheduleCommand : CreateCommand<LecturesSchedule>, ICommand
{
    public CreateLectureScheduleCommand(LecturesSchedule model) : base(model)
    {
    }
}