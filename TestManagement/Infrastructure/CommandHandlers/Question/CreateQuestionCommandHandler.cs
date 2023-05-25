using CQS.Command.Question;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Question;

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