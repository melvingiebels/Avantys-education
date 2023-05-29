namespace TestManagement.CQS.Queries.Test;

public interface IGetAllGradedTests : IQuery
{
    IEnumerable<Domain.Test> Excecute();
}