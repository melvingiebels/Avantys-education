using StudyProgramManagement.Commands.Commands;
using StudyProgramManagement.Commands.Commands.Module;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Module;

public class UpdateModuleCommandHandler: EFCommandHandlerBase<UpdateModuleCommand, StudyProgramManagementDbContext>
{
    public UpdateModuleCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateModuleCommand command)
    {
        DbContext.Modules.Update(command.Model);
        DbContext.SaveChanges();
    }
}