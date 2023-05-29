namespace TestManagement.CQS.Command.Question;

public class RemoveQuestionFromTestCommand : ICommand
{
    public readonly Guid QuestionId;
    public readonly Guid TestId;

    public RemoveQuestionFromTestCommand(Guid testId, Guid questionId)
    {
        TestId = testId;
        QuestionId = questionId;
    }
}