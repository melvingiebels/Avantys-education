namespace CQS.Queries.Student;

public interface IGetTestsMadeByStudent : IQuery
{
    IEnumerable<Domain.Test> Excecute(Guid studentId);
}