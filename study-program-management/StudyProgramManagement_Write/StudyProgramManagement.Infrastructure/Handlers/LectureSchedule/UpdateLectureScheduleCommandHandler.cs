using StudyProgramManagement.Commands.Commands.LectureSchedule;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.LectureSchedule;

public class
    UpdateLectureScheduleCommandHandler : EFCommandHandlerBase<UpdateLectureScheduleCommand,
        StudyProgramManagementDbContext>
{
    public UpdateLectureScheduleCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateLectureScheduleCommand command)
    {
        DbContext.LecturesSchedule.Update(command.Model);
        DbContext.SaveChanges();
    }
}