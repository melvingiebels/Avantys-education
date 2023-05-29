namespace TestManagement.CQS.Queries.OpenQuestion;

public interface IGetOpenQuestions:IQuery
{
    IEnumerable<Domain.Questions.OpenQuestion> Excecute();
}