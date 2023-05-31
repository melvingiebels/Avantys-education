using StudyProgramManagement.Commands.Commands;
using StudyProgramManagement.Commands.Commands.LectureSchedule;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.LectureSchedule;

public class RemoveLectureScheduleCommandHandler: EFCommandHandlerBase<RemoveLectureScheduleCommand, StudyProgramManagementDbContext>
{
    public RemoveLectureScheduleCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveLectureScheduleCommand command)
    {
        DbContext.LecturesSchedule.Remove(DbContext.LecturesSchedule.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}