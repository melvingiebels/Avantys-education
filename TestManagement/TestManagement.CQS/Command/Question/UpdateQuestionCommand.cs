namespace TestManagement.CQS.Command.Question;

public class UpdateQuestionCommand: ICommand
{
    public Domain.Questions.Question Question;

    public UpdateQuestionCommand(Domain.Questions.Question question)
    {
        Question = question;
    }
}