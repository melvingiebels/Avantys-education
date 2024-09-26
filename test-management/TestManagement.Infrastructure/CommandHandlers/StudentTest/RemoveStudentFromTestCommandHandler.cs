using TestManagement.CQS.Command.Student;
using TestManagement.CQS.Domain;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.StudentTest;

public class
    RemoveStudentFromTestCommandHandler : EFCommandHandlerBase<RemoveStudentFromTestCommand, TestManagementDbContext>
{
    public RemoveStudentFromTestCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveStudentFromTestCommand command)
    {
        DbContext.StudentsTests.Add(new StudentsTests(new Guid(), command.TestId, null));
    }
}