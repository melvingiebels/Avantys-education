using CQS.Command;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core;

public abstract class EFCommandHandlerBase<TCommand, TContext> : ICommandHandler<TCommand>, IDisposable
    where TCommand : ICommand
    where TContext : DbContext
{
    protected readonly TContext DbContext;

    protected EFCommandHandlerBase(TContext dbContext)
    {
        DbContext = dbContext;
    }

    public abstract void Execute(TCommand command);

    public void Dispose()
    {
        DbContext.Dispose();
    }
}