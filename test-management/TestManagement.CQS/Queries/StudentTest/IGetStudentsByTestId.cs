namespace TestManagement.CQS.Queries.StudentTest;

public interface IGetStudentsByTestId : IQuery
{
    IEnumerable<Domain.Student> Excecute(Guid studentId);
}