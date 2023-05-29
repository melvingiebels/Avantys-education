namespace TestManagement.CQS.Command.Question;

public class AddQuestionToTestCommand : ICommand
{
    public readonly Guid QuestionId;
    public readonly Guid TestId;

    public AddQuestionToTestCommand(Guid testId, Guid questionId)
    {
        TestId = testId;
        QuestionId = questionId;
    }
}