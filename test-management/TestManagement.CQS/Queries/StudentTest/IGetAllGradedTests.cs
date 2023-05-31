namespace TestManagement.CQS.Queries.StudentTest;

public interface IGetAllGradedTests : IQuery
{
    IEnumerable<Domain.StudentsTests> Excecute();
}