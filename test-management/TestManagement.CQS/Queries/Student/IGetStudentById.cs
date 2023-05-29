namespace TestManagement.CQS.Queries.Student;

public interface IGetStudentById : IQuery
{
    Domain.Student Excecute(Guid studentId);
}