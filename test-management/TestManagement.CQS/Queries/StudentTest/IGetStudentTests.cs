namespace TestManagement.CQS.Queries.StudentTest;

public interface IGetStudentTests : IQuery
{
    IEnumerable<Domain.StudentsTests> Excecute();
}