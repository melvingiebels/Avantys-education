namespace TestManagement.CQS.Queries.McQuestion;

public interface IGetMcQuestions : IQuery
{
    IEnumerable<Domain.Questions.McQuestion> Excecute();
}