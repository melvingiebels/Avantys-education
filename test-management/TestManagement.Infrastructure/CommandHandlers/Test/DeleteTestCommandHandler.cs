using TestManagement.CQS.Command.Test;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Test;

public class DeleteTestCommandHandler : EFCommandHandlerBase<DeleteTestCommand, TestManagementDbContext>
{
    public DeleteTestCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(DeleteTestCommand command)
    {
        DbContext.Tests.Remove(command.Test);
        DbContext.SaveChanges();
    }
}