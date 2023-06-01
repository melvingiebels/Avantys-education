using TestManagement.CQS.Queries.StudentTest;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.StudentTests;

public class GetStudentTests : EFQueryBase<TestManagementDbContext>, IGetStudentTests
{
    public GetStudentTests(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.StudentsTests> Excecute()
    {
        return DbContext.StudentsTests.ToList();
    }
}