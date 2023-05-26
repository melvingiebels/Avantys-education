namespace TestManagement.CQS.Queries.Question;

public interface IGetAllQuestionsFromTest:IQuery
{
    IEnumerable<Domain.Questions.Question> Excecute(Guid testId);
}