using StudyProgramManagement.Commands.Commands.Teacher;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Teacher;

public class RemoveTeacherCommandHandler : EFCommandHandlerBase<RemoveTeacherCommand, StudyProgramManagementDbContext>
{
    public RemoveTeacherCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveTeacherCommand command)
    {
        DbContext.Teachers.Remove(DbContext.Teachers.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}