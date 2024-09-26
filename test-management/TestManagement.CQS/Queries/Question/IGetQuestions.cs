namespace TestManagement.CQS.Queries.Question;

public interface IGetQuestions : IQuery
{
    IEnumerable<Domain.Questions.Question> Excecute();
}