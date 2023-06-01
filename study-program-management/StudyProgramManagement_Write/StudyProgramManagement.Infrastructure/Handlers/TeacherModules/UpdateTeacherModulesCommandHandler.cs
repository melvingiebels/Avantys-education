using StudyProgramManagement.Commands.Commands.TeacherModules;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.TeacherModules;

public class
    UpdateTeacherModulesCommandHandler : EFCommandHandlerBase<UpdateTeacherModulesCommand,
        StudyProgramManagementDbContext>
{
    public UpdateTeacherModulesCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateTeacherModulesCommand command)
    {
        DbContext.TeacherModules.Update(command.Model);
        DbContext.SaveChanges();
    }
}