using StudyProgramManagement.Commands.Commands.LectureSchedule;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.LectureSchedule;

public class
    CreateLectureScheduleCommandHandler : EFCommandHandlerBase<CreateLectureScheduleCommand,
        StudyProgramManagementDbContext>
{
    public CreateLectureScheduleCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateLectureScheduleCommand command)
    {
        DbContext.LecturesSchedule.Add(command.Model);
        DbContext.SaveChanges();
    }
}