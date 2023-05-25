using CQS.Command.Question;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.CommandHandlers.Question;

public class AddQuestionToTestCommandHandler : EFCommandHandlerBase<AddQuestionToTestCommand, TestManagementDbContext>
{
    public AddQuestionToTestCommandHandler(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public override void Execute(AddQuestionToTestCommand command)
    {
        var questionToBeAdded =
            DbContext.TestQuestions.FirstOrDefault(tq =>
                tq.TestId == command.TestId && tq.QuestionId == command.QuestionId);
        DbContext.TestQuestions.Remove(questionToBeAdded!);
        DbContext.SaveChanges();
    }
}