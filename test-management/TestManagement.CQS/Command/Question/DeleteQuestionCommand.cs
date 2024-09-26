namespace TestManagement.CQS.Command.Question;

public class DeleteQuestionCommand : ICommand
{
    public Domain.Questions.Question Question;

    public DeleteQuestionCommand(Domain.Questions.Question question)
    {
        Question = question;
    }
}