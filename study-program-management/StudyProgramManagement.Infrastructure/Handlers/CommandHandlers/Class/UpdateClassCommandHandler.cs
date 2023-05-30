using StudyProgramManagement.Commands.Commands.Class;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Class;

public class UpdateClassCommandHandler : EFCommandHandlerBase<UpdateClassCommand, StudyProgramManagementDbContext>
{
    public UpdateClassCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateClassCommand command)
    {
        DbContext.Classes.Add(command.Model);
        DbContext.SaveChanges();
    }
}