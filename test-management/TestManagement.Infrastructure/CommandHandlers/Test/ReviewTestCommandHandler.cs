using TestManagement.CQS.Command.Test;
using TestManagement.CQS.Domain;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Test;

public class ReviewTestCommandHandler : EFCommandHandlerBase<ReviewTestCommand, TestManagementDbContext>
{
    public ReviewTestCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(ReviewTestCommand command)
    {
        DbContext.StudentsTests.Add(new StudentsTests(new Guid(), command.TestId, command.Score));
        DbContext.SaveChanges();
    }
}