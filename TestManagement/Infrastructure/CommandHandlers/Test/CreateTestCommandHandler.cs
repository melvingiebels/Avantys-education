using CQS.Command.Test;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Test;

public class CreateTestCommandHandler : EFCommandHandlerBase<CreateTestCommand, TestManagementDbContext>
{
    public CreateTestCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateTestCommand command)
    {
        DbContext.Tests.Add(command.Test);
        DbContext.SaveChanges();
    }
}