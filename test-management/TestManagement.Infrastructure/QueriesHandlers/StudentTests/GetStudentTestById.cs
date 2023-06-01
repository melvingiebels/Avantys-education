using TestManagement.CQS.Queries.StudentTest;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.StudentTests;

public class GetStudentTestById : EFQueryBase<TestManagementDbContext>, IGetStudentTestsById
{
    public GetStudentTestById(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public CQS.Domain.StudentsTests Excecute(Guid studentTestId)
    {
        return DbContext.StudentsTests.FirstOrDefault(c => c.Id == studentTestId)!;
    }
}