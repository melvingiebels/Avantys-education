namespace CQS.Command.Question;

public class CreateQuestionCommand : ICommand
{
    public Domain.Questions.Question Question;

    public CreateQuestionCommand(Domain.Questions.Question question)
    {
        Question = question;
    }
}