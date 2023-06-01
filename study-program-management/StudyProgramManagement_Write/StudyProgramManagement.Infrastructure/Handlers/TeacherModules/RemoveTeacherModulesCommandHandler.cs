using StudyProgramManagement.Commands.Commands.TeacherModules;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.TeacherModules;

public class
    RemoveTeacherModulesCommandHandler : EFCommandHandlerBase<RemoveTeacherModulesCommand,
        StudyProgramManagementDbContext>
{
    public RemoveTeacherModulesCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveTeacherModulesCommand command)
    {
        DbContext.TeacherModules.Remove(DbContext.TeacherModules.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}