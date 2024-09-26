using TestManagement.CQS.Command.Student;
using TestManagement.CQS.Domain;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.StudentTest;

public class UpdateStudentTestCommandHandler : EFCommandHandlerBase<UpdateStudentTestCommand, TestManagementDbContext>
{
    public UpdateStudentTestCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateStudentTestCommand command)
    {
        DbContext.StudentsTests.Remove(command.StudentsTests);
    }
}