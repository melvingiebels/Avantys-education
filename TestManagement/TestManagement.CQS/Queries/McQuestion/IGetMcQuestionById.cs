namespace TestManagement.CQS.Queries.McQuestion;

public interface IGetMcQuestionById
{
    Domain.Questions.McQuestion? Excecute(Guid questionId);
}