namespace CQS.Queries.OpenQuestion;

public interface IGetOpenQuestionById
{
    Domain.Questions.OpenQuestion Excecute(Guid questionId);
}