namespace TestManagement.CQS.Queries.Test;

public interface IGetTestById : IQuery
{
    Domain.Test Excecute(Guid testId);
}