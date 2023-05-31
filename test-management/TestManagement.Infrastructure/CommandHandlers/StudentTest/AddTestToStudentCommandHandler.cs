using TestManagement.CQS.Command.Student;
using TestManagement.CQS.Domain;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Student;

public class AddTestToStudentCommandHandler : EFCommandHandlerBase<AddTestToStudentCommand, TestManagementDbContext>
{
    public AddTestToStudentCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(AddTestToStudentCommand command)
    {
        DbContext.StudentsTests.Add(new StudentsTests(new Guid(), command.TestId, null));
    }
}