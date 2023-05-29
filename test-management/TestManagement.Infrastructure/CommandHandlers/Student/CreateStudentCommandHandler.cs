using TestManagement.CQS.Command.Student;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Student;

public class CreateStudentCommandHandler : EFCommandHandlerBase<CreateStudentCommand, TestManagementDbContext>
{
    public CreateStudentCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateStudentCommand command)
    {
        DbContext.Students.Add(command.Student);
        DbContext.SaveChanges();
    }
}