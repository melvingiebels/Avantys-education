using CQS.Command.Question;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Question;

public class
    RemoveQuestionFromTestCommandHandler : EFCommandHandlerBase<RemoveQuestionFromTestCommand, TestManagementDbContext>
{
    public RemoveQuestionFromTestCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(RemoveQuestionFromTestCommand command)
    {
        var questionToBeRemoved =
            DbContext.TestQuestions.FirstOrDefault(tq =>
                tq.TestId == command.TestId && tq.QuestionId == command.QuestionId);
        DbContext.TestQuestions.Remove(questionToBeRemoved!);
        DbContext.SaveChanges();
    }
}