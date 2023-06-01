using StudyProgramManagement.Commands.Commands.Student;
using StudyProgramManagement.Infrastructure.Context;
using StudyProgramManagement.Infrastructure.Core;

namespace StudyProgramManagement.Infrastructure.Handlers.Student;

public class CreateStudentCommandHandler : EFCommandHandlerBase<CreateStudentCommand, StudyProgramManagementDbContext>
{
    public CreateStudentCommandHandler(StudyProgramManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateStudentCommand command)
    {
        DbContext.Students.Add(command.Model);
        DbContext.SaveChanges();
    }
}