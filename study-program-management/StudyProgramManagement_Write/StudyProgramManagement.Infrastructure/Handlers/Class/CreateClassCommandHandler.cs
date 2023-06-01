using StudyProgramManagement.Commands.Commands.Class;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Class;

public class CreateClassCommandHandler : EFCommandHandlerBase<CreateClassCommand, StudyProgramManagementDbContext>
{
    public CreateClassCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateClassCommand command)
    {
        DbContext.Classes.Add(command.Model);
        DbContext.SaveChanges();
    }
}