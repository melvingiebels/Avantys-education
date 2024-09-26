using TestManagement.CQS.Command.Question;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Question;

public class DeleteQuestionCommandHandler : EFCommandHandlerBase<DeleteQuestionCommand, TestManagementDbContext>
{
    public DeleteQuestionCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(DeleteQuestionCommand command)
    {
        DbContext.Questions.Add(command.Question);
        DbContext.SaveChanges();
    }
}