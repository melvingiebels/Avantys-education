using StudyProgramManagement.Commands.Commands.Lecture;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Lecture;

public class RemoveLectureCommandHandler : EFCommandHandlerBase<RemoveLectureCommand, StudyProgramManagementDbContext>
{
    public RemoveLectureCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveLectureCommand command)
    {
        DbContext.Lectures.Remove(DbContext.Lectures.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}