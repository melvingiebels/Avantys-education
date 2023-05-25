using CQS.Command.Test;
using CQS.Domain;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Test;

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