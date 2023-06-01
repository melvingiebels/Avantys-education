using StudyProgramManagement.Commands.Commands.StudyProgram;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.StudyProgram;

public class
    RemoveStudyProgramCommandHandler : EFCommandHandlerBase<RemoveStudyProgramCommand, StudyProgramManagementDbContext>
{
    public RemoveStudyProgramCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveStudyProgramCommand command)
    {
        DbContext.StudyPrograms.Remove(DbContext.StudyPrograms.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}