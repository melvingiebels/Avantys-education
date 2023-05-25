using TestManagement.CQS.Command.Test;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Test;

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