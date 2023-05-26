namespace TestManagement.CQS.Queries.Student;

public interface IGetStudents : IQuery
{
    IEnumerable<Domain.Student> Excecute();
}