namespace CQS.Queries.Test;

public interface IGetAllTests : IQuery
{
    IEnumerable<Domain.Test> Excecute();
}