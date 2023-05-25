using CQS.Command.Student;
using CQS.Domain;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Student;

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