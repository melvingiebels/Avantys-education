using StudyProgramManagement.Commands.Commands.TeacherModules;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.TeacherModules;

public class CreateTeacherModulesCommandHandler: EFCommandHandlerBase<CreateTeacherModulesCommand, StudyProgramManagementDbContext>
{
    public CreateTeacherModulesCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateTeacherModulesCommand command)
    {
        DbContext.TeacherModules.Add(command.Model);
        DbContext.SaveChanges();
    }
}