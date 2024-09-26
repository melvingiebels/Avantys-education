using TestManagement.CQS.Command.Question;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Question;

public class UpdateQuestionCommandHandler : EFCommandHandlerBase<UpdateQuestionCommand, TestManagementDbContext>
{
    public UpdateQuestionCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(UpdateQuestionCommand command)
    {
        DbContext.Questions.Update(command.Question);
        DbContext.SaveChanges();
    }
}