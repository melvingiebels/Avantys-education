namespace TestManagement.CQS.Queries.Question;

public interface IGetQuestionById : IQuery
{
    Domain.Questions.Question Excecute(Guid questionId);
}