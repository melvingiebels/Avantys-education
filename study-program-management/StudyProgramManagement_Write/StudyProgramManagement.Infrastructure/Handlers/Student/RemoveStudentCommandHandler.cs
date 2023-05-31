using StudyProgramManagement.Commands.Commands;
using StudyProgramManagement.Commands.Commands.Student;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.CommandHandlers.Student;

public class RemoveStudentCommandHandler: EFCommandHandlerBase<RemoveStudentCommand, StudyProgramManagementDbContext>
{
    public RemoveStudentCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveStudentCommand command)
    {
        DbContext.Students.Remove(DbContext.Students.FirstOrDefault(c => c.Id == command.Id)!);
        DbContext.SaveChanges();
    }
}