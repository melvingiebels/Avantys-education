using TestManagement.CQS.Domain;
using TestManagement.CQS.Queries.StudentTest;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.StudentTests;

public class GetAllGradedTests : EFQueryBase<TestManagementDbContext>, IGetAllGradedTests
{
    public GetAllGradedTests(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<StudentsTests> Excecute()
    {
        var gTest = new List<StudentsTests>();
        DbContext.StudentsTests.ToList().ForEach(t =>
        {
            if (t.Grade != 0)
                gTest.Add(t);
        });
        return gTest;
    }
}