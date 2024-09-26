using TestManagement.CQS.Queries.StudentTest;
using TestManagement.Infrastructure.Context;
using TestManagement.Infrastructure.Core;

namespace TestManagement.Infrastructure.QueriesHandlers.StudentTests;

public class GetStudentsByTestId : EFQueryBase<TestManagementDbContext>, IGetStudentsByTestId
{
    public GetStudentsByTestId(TestManagementDbContext dbContext) : base(dbContext)
    {
    }

    public IEnumerable<CQS.Domain.Student> Excecute(Guid testId)
    {
        var studentList = new List<CQS.Domain.Student>();
        foreach (var studentsTests in DbContext.StudentsTests.Where(c => c.TestId == testId))
        {
            studentList.Add(DbContext.Students.FirstOrDefault(s => s.Id == studentsTests.StudentId)!);
        }

        return studentList;
    }
}