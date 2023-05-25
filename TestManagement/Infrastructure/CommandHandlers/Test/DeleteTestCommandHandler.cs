using CQS.Command.Test;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Test;

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