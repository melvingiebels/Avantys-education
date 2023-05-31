using StudyProgramManagement.Commands.Commands.Module;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Module;

public class CreateModuleCommandHandler: EFCommandHandlerBase<CreateModuleCommand, StudyProgramManagementDbContext>
{
    public CreateModuleCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateModuleCommand command)
    {
        DbContext.Modules.Add(command.Model);
        DbContext.SaveChanges();
    }
}