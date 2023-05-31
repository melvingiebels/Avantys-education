namespace TestManagement.CQS.Queries.StudentTest;

public interface IGetTestsByStudentId : IQuery
{
    IEnumerable<Domain.Test> Excecute(Guid studentId);
}