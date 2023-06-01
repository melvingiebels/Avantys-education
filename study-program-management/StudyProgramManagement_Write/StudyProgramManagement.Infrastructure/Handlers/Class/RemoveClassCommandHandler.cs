using StudyProgramManagement.Commands.Commands.Class;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Class;

public class RemoveClassCommandHandler : EFCommandHandlerBase<RemoveClassCommand, StudyProgramManagementDbContext>
{
    public RemoveClassCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveClassCommand command)
    {
        DbContext.Classes.Remove(DbContext.Classes.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}