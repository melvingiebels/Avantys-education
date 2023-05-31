namespace TestManagement.CQS.Queries.OpenQuestion;

public interface IGetOpenQuestionById : IQuery
{
    Domain.Questions.OpenQuestion Excecute(Guid questionId);
}