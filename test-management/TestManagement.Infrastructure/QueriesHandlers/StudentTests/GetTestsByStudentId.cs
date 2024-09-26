using TestManagement.CQS.Queries.StudentTest;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.StudentTests;

public class GetTestsByStudentId : EFQueryBase<TestManagementDbContext>, IGetTestsByStudentId
{
    public GetTestsByStudentId(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Test> Excecute(Guid studentId)
    {
        var testsList = new List<CQS.Domain.Test>();
        foreach (var studentsTests in DbContext.StudentsTests.Where(c => c.StudentId == studentId))
        {
            testsList.Add(DbContext.Tests.FirstOrDefault(s => s.Id == studentsTests.TestId)!);
        }

        return testsList;
    }
}