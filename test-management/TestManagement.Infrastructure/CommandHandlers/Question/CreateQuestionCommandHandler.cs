using TestManagement.CQS.Command.Question;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.CommandHandlers.Question;

public class CreateQuestionCommandHandler : EFCommandHandlerBase<CreateQuestionCommand, TestManagementDbContext>
{
    public CreateQuestionCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(CreateQuestionCommand command)
    {
        DbContext.Questions.Add(command.Question);
        DbContext.SaveChanges();
    }
}