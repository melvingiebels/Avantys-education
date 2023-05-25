using CQS.Queries.Student;
using Infrastructure.Context;
using Infrastructure.Core;

namespace Infrastructure.QueriesHandlers.Student;

public class GetTestsMadeByStudent : EFQueryBase<TestManagementDbContext>, IGetTestsMadeByStudent
{
    public GetTestsMadeByStudent(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Test> Excecute(Guid studentId)
    {
        var tList = new List<CQS.Domain.Test>();
        DbContext.StudentsTests.ToList().ForEach(t =>
        {
            if (t.StudentId.Equals(studentId))
                tList.Add(DbContext.Tests.FirstOrDefault(ts => ts.Id == t.TestId)!);
        });
        return tList;
    }
}