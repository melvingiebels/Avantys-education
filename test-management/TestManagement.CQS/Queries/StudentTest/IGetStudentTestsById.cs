namespace TestManagement.CQS.Queries.StudentTest;

public interface IGetStudentTestsById : IQuery
{
    Domain.StudentsTests Excecute(Guid studentTestId);
}