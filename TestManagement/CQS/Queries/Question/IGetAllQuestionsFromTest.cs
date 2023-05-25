namespace CQS.Queries.Question;

public interface IGetAllQuestionsFromTest
{
    IEnumerable<Domain.Questions.Question> Excecute(Guid testId);
}