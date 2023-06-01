using StudyProgramManagement.Commands.Commands.Student;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Student;

public class UpdateStudentCommandHandler : EFCommandHandlerBase<UpdateStudentCommand, StudyProgramManagementDbContext>
{
    public UpdateStudentCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateStudentCommand command)
    {
        DbContext.Students.Update(command.Model);
        DbContext.SaveChanges();
    }
}