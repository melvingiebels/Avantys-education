namespace TestManagement.CQS.Queries.McQuestion;

public interface IGetMcQuestionById : IQuery
{
    Domain.Questions.McQuestion? Excecute(Guid questionId);
}