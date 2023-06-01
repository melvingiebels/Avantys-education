using StudyProgramManagement.Commands.Commands.Module;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Module;

public class RemoveModuleCommandHandler : EFCommandHandlerBase<RemoveModuleCommand, StudyProgramManagementDbContext>
{
    public RemoveModuleCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveModuleCommand command)
    {
        DbContext.Modules.Remove(DbContext.Modules.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}